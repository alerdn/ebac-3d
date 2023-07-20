using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    [Header("UI")]
    [SerializeField] private List<UIFillUpdater> _uiUpdaters;

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
    }

    public virtual void ResetLife()
    {
        _currentLife = _startLife;
        UpdateUI();
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
        foreach (var uiUpdater in _uiUpdaters)
        {
            uiUpdater.UpdateValue(_currentLife / _startLife);
        }
    }
}
