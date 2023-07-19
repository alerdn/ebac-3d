using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    [SerializeField] private bool _destroyOnKill;
    [SerializeField] private float _startLife = 10f;
    private float _currentLife;

    private void Awake()
    {
        Init();
    }

    protected void Init()
    {
        ResetLife();
    }

    #region Debug

    [Button]
    private void Damage()
    {
        Damage(5f);
    }

    #endregion

    public virtual void ResetLife()
    {
        _currentLife = _startLife;
    }

    public virtual void Kill()
    {
        if (_destroyOnKill) Destroy(gameObject, 3f);

        OnKill?.Invoke(this);
    }

    public virtual void Damage(float damage)
    {
        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }

        OnDamage?.Invoke(this);
    }
}
