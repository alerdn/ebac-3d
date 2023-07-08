using UnityEngine;

public class StateBase
{
    public virtual void OnStateEnter()
    {
        Debug.Log("OnStateEnter1");
    }

    public virtual void OnStateStay()
    {
        Debug.Log("OnStateStay");
    }

    public virtual void OnStateExit()
    {
        Debug.Log("OnStateExit");
    }
}
