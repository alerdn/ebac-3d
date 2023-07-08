using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        NONE
    }

    public Dictionary<States, StateBase> DictionaryState;

    [SerializeField] private float _timeToStartGame = 1f;

    private StateBase _currentState;

    private void Awake()
    {
        DictionaryState = new Dictionary<States, StateBase>();
        DictionaryState.Add(States.NONE, new StateBase());

        SwitchState(States.NONE);

        Invoke(nameof(StartGame), _timeToStartGame);
    }

    [Button]
    private void StartGame()
    {
        SwitchState(States.NONE);
    }

    private void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = DictionaryState[state];
        _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }
}
