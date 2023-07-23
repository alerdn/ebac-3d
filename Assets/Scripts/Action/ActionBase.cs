using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase : MonoBehaviour
{
    [SerializeField] protected ItemType itemType;

    protected Inputs inputs;
    protected ItemSetup itemSetup;

    private void OnEnable()
    {
        if (inputs != null) inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    private void Start()
    {
        itemSetup = ItemManager.Instance.GetSetupByType(itemType);
        StartInputs();
    }

    protected virtual void StartInputs()
    {
        inputs = new Inputs();
        inputs.Enable();
    }


}
