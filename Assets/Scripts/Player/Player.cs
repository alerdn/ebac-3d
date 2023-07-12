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
    [SerializeField] private float _turnSpeed = 300f;
    [SerializeField] private float _jumpSpeed = 15f;
    [SerializeField] private float _gravity = -9.8f;

    [Header("Run Setup")]
    [SerializeField] private KeyCode _keyRun = KeyCode.LeftShift;
    [SerializeField] private float _runSpeedModifier = 1.5f;

    private CharacterController _charController;
    private float _verticalSpeed;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
        StartStateMachine();
    }

    private void Update()
    {
        transform.Rotate(0f, Input.GetAxis("Horizontal") * _turnSpeed * Time.deltaTime, 0f);

        float inputAxisVertical = Input.GetAxis("Vertical");
        Vector3 speedVector = transform.forward * inputAxisVertical * _moveSpeed;

        if (_charController.isGrounded)
        {
            _verticalSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _verticalSpeed = _jumpSpeed;
            }
        }

        _animator.speed = 1f;
        bool isWalking = inputAxisVertical != 0;
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
