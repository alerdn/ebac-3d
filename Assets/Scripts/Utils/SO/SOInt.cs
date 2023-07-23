using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOInt : ScriptableObject
{
    public event Action<int> OnUpdate;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            OnUpdate?.Invoke(_value);
        }
    }

    [SerializeField] private int _value;
}
