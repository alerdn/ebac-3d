using System.Collections.Generic;


public class StateMachine<T> where T : System.Enum
{
    public StateBase CurrentState => _currentState;
    public Dictionary<T, StateBase> DictonaryState => _dictionaryState;

    private Dictionary<T, StateBase> _dictionaryState;
    private StateBase _currentState;

    public StateMachine()
    {
        _dictionaryState = new Dictionary<T, StateBase>();
    }

    public void RegisterStates(T typeEnum, StateBase state)
    {
        _dictionaryState.Add(typeEnum, state);
    }

    private void SwitchState(T state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = _dictionaryState[state];
        _currentState.OnStateEnter();
    }

    public void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }
}
