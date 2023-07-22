using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Player : MonoBehaviour
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
    [SerializeField] private float _jumpSpeed = 15f;
    [SerializeField] private float _gravity = -9.8f;

    [Header("Run Setup")]
    [SerializeField] private float _runSpeedModifier = 1.5f;

    [Header("Life")]
    [SerializeField] private List<FlashColor> _flashColors;

    private CharacterController _charController;
    private HealthBase _healthBase;
    private float _verticalSpeed;
    private float _turnSmoothVelocity;
    private Inputs _inputs;
    private bool _canRun;
    private bool _isAlive = true;

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

        _healthBase = GetComponent<HealthBase>();
        _healthBase.OnDamage += Damage;
        _healthBase.OnKill += Kill;

        StartInputs();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void StartInputs()
    {
        _inputs = new Inputs();
        _inputs.Enable();
        _inputs.Gameplay.Run.performed += (ctx) => _canRun = true;
        _inputs.Gameplay.Run.canceled += (ctx) => _canRun = false;
    }

    public void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 speedVector = direction * _moveSpeed;

        if (_charController.isGrounded)
        {
            _verticalSpeed = 0;
            if (Input.GetButtonDown("Jump"))
            {
                _verticalSpeed = _jumpSpeed;
            }
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

        _verticalSpeed -= _gravity * Time.deltaTime;
        speedVector.y = _verticalSpeed;

        if (isWalking)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, .1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

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

    [Button]
    public void Respawn()
    {
        if (CheckpointManager.Instance.HasCheckpoint())
        {
            transform.position = CheckpointManager.Instance.GetLastCheckpointPosition();
        }
    }
}
