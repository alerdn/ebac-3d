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

    private void Start()
    {
        StateMachine = new StateMachine<PlayerState>();
        StateMachine.RegisterState(PlayerState.WALK, new PlayerStateWalk());
        StateMachine.RegisterState(PlayerState.STOP, new PlayerStateStop());
        StateMachine.RegisterState(PlayerState.JUMP, new PlayerStateJump());

        StateMachine.SwitchState(PlayerState.STOP);
    }
}
