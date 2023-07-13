using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        WALK,
        STOP,
        JUMP
    }

    public StateMachine<PlayerState> StateMachine { get; private set; }
    public Animator Animator => _animator;

    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed = 25f;
    [SerializeField] private float _jumpSpeed = 15f;
    [SerializeField] private float _gravity = -9.8f;

    [Header("Run Setup")]
    [SerializeField] private KeyCode _keyRun = KeyCode.LeftShift;
    [SerializeField] private float _runSpeedModifier = 1.5f;

    private CharacterController _charController;
    private float _verticalSpeed;
    private float _turnSmoothVelocity;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
        StartStateMachine();
    }

    private void Update()
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
        bool isWalking = direction.magnitude >= .1f;
        if (isWalking)
        {
            if (Input.GetKey(_keyRun))
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

    private void StartStateMachine()
    {
        StateMachine = new StateMachine<PlayerState>();
        StateMachine.RegisterState(PlayerState.WALK, new PlayerStateWalk());
        StateMachine.RegisterState(PlayerState.STOP, new PlayerStateStop());
        StateMachine.RegisterState(PlayerState.JUMP, new PlayerStateJump());

        StateMachine.SwitchState(PlayerState.STOP);
    }
}
