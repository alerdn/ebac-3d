using System.Collections.Generic;

public class StateMachine<T> where T : System.Enum
{
    public StateBase CurrentState => _currentState;
    public Dictionary<T, StateBase> DictonaryState => _dictionaryState;

    private Dictionary<T, StateBase> _dictionaryState;
    private StateBase _currentState;

    #region Constructors

    public StateMachine()
    {
        _dictionaryState = new Dictionary<T, StateBase>();
    }

    public StateMachine(T state)
    {
        _dictionaryState = new Dictionary<T, StateBase>();
        SwitchState(state);
    }

    #endregion

    #region Public Methods

    public void RegisterState(T typeEnum, StateBase state)
    {
        _dictionaryState.Add(typeEnum, state);
    }

    public void SwitchState(T state, params object[] objs)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = _dictionaryState[state];
        _currentState.OnStateEnter(objs);
    }

    public void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }

    #endregion
}
