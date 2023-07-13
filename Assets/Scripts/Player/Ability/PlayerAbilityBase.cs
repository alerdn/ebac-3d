using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityBase : MonoBehaviour
{
    protected Player _player;
    protected Inputs _inputs;

    private void OnValidate()
    {
        if (_player == null) _player = GetComponent<Player>();
    }

    private void OnEnable() {
        if (_inputs != null) _inputs.Enable();
    }

    private void Start()
    {
        _inputs = new Inputs();
        _inputs.Enable();

        Init();
        OnValidate();
        RegisterListeners();
    }

    private void OnDisable() {
        _inputs.Disable();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    protected virtual void Init() { }

    protected virtual void RegisterListeners() { }

    protected virtual void RemoveListeners() { }
}
