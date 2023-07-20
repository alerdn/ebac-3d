using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    [Header("UI")]
    [SerializeField] private UIFillUpdater _uiUpdater;

    [Header("Setup")]
    [SerializeField] private float _startLife = 10f;
    [SerializeField] private bool _destroyOnKill;

    [Header("Debug")]
    [SerializeField] private float _currentLife;

    private void Awake()
    {
        Init();
    }

    protected void Init()
    {
        ResetLife();
        UpdateUI();
    }

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

        UpdateUI();
        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 direction)
    {
        Damage(damage);
    }

    private void UpdateUI()
    {
        if (_uiUpdater != null)
        {
            _uiUpdater.UpdateValue(_currentLife / _startLife);
        }
    }
}
