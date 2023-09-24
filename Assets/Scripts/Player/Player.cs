using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public enum PlayerState
    {
        WALK,
        STOP,
        JUMP
    }

    public Animator Animator => _animator;
    public HealthBase Health => _healthBase;

    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed = 25f;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _jumpSpeed = 15f;

    [Header("VFX")]
    [SerializeField] private ParticleSystem _vfxRun;
    [SerializeField] private ParticleSystem _vfxJump;

    [Header("Run Setup")]
    [SerializeField] private float _runSpeedModifier = 1.5f;

    [Header("Life")]
    [SerializeField] private List<FlashColor> _flashColors;

    [Header("Cloth")]
    [SerializeField] private ClothChanger _clothChanger;

    private CharacterController _charController;
    private HealthBase _healthBase;
    private float _verticalSpeed;
    private float _turnSmoothVelocity;
    private Inputs _inputs;
    private bool _canRun;
    private bool _isAlive = true;
    Vector2 _inputDirection = Vector2.zero;
    private Transform _cam;
    private bool _isJumping;

    private void OnEnable()
    {
        if (_inputs != null) _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
        _cam = Camera.main.transform;

        _healthBase = GetComponent<HealthBase>();
        _healthBase.OnDamage += Damage;
        _healthBase.OnKill += Kill;

        StartInputs();
    }

    private void Update()
    {
        Movement();
    }

    private void StartInputs()
    {
        _inputs = new Inputs();
        _inputs.Enable();
        _inputs.Gameplay.Run.performed += (ctx) => _canRun = true;
        _inputs.Gameplay.Run.canceled += (ctx) => _canRun = false;

        _inputs.Gameplay.Move.performed += (ctx) => _inputDirection = ctx.ReadValue<Vector2>();
        _inputs.Gameplay.Move.canceled += (ctx) => _inputDirection = Vector2.zero;
    }

    private void Movement()
    {
        float horizontal = _inputDirection.x;
        float vertical = _inputDirection.y;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        /// Cria o vector de movimentação do player levando em consideração
        /// a direção das teclas e a rotação da câmera
        /// Ref: https://www.youtube.com/watch?v=4HpC--2iowE
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, .1f);
        Vector3 speedVector = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized * _moveSpeed;

        if (_charController.isGrounded)
        {
            if (_vfxRun.isPaused)
            {
                _vfxRun.Play();
            }

            if (_isJumping)
            {
                _isJumping = false;
                _animator.SetTrigger("Land");
            }

            _verticalSpeed = 0;
            if (_inputs.Gameplay.Jump.triggered)
            {
                _verticalSpeed = _jumpSpeed;

                _isJumping = true;
                _animator.SetTrigger("Jump");
                _vfxJump.Play();
            }
        }
        else
        {
            _vfxRun.Pause();
        }

        _animator.speed = 1f;
        bool isWalking = direction.magnitude >= .1f && _isAlive;
        if (isWalking)
        {
            if (_canRun)
            {
                speedVector *= _runSpeedModifier;
                _animator.speed = _runSpeedModifier;
            }
        }
        else
        {
            speedVector = Vector3.zero;
        }

        _verticalSpeed -= _gravity * Time.deltaTime;
        speedVector.y = _verticalSpeed;

        if (isWalking) transform.rotation = Quaternion.Euler(0f, angle, 0f);

        _charController.Move(speedVector * Time.deltaTime);
        _animator.SetBool("Run", isWalking);
    }

    #region Life

    private void Revive()
    {
        _isAlive = true;
        _animator.SetTrigger("Revive");
        _healthBase.ResetLife();
        Respawn();
        Invoke(nameof(TurnOnCollider), .1f);
    }

    private void TurnOnCollider()
    {
        _charController.enabled = true;
    }

    private void Damage(HealthBase hb)
    {
        _flashColors.ForEach(flash => flash.Flash());
        EffectManager.Instance.ChangeVignette();
        ShakeCamera.Instance.Shake(3f, 3f, .2f);
    }

    private void Kill(HealthBase hb)
    {
        if (_isAlive)
        {
            _isAlive = false;
            _charController.enabled = false;
            _animator.SetTrigger("Death");

            Invoke(nameof(Revive), 2f);
            Notification.Instance.ShowNotification("Você foi derrotado", 2f);
        }
    }

    #endregion

    public void Respawn()
    {
        if (CheckpointManager.Instance.HasCheckpoint())
        {
            transform.position = CheckpointManager.Instance.GetLastCheckpointPosition();
        }
    }

    public void ChangeSpeed(float speed, float duration)
    {
        StartCoroutine(ChangeSpeedRoutine(speed, duration));
    }

    private IEnumerator ChangeSpeedRoutine(float speed, float duration)
    {
        float defaultSpeed = _moveSpeed;
        _moveSpeed = speed;
        yield return new WaitForSeconds(duration);
        _moveSpeed = defaultSpeed;
    }

    public void ChangeTexture(ClothSetup setup, float duration)
    {
        StartCoroutine(ChangeTextureRoutine(setup, duration));
    }

    private IEnumerator ChangeTextureRoutine(ClothSetup setup, float duration)
    {
        _clothChanger.ChangeTexture(setup);
        yield return new WaitForSeconds(duration);
        _clothChanger.ResetTexture();
    }
}
