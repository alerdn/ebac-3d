using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMExample : MonoBehaviour
{
    public enum ExampleEnum
    {
        STATE_ONE,
        STATE_TWO,
        STATE_THREE
    }

    public StateMachine<ExampleEnum> StateMachine { get; private set; }


    private void Start()
    {
        StateMachine = new StateMachine<ExampleEnum>();
        StateMachine.RegisterState(ExampleEnum.STATE_ONE, new StateBase());
        StateMachine.RegisterState(ExampleEnum.STATE_TWO, new StateBase());
        StateMachine.RegisterState(ExampleEnum.STATE_THREE, new StateBase());
    }
}
