using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] private AnimationBase _animationBase;
    [SerializeField] private float _startLife = 10f;

    [Header("Start Animation")]
    [SerializeField] private float _startAnimationDuration = .2f;
    [SerializeField] private Ease _startAnimationEase = Ease.OutBack;
    [SerializeField] private bool _startWithBornAnimation = true;

    private float _currentLife;
    private Collider _collider;

    private void Awake()
    {
        Init();
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            OnDamage(5f);
        }
    }

    public void OnDamage(float damage)
    {
        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    #region  Animation

    private void BornAnimation()
    {
        transform.DOScale(0, _startAnimationDuration).SetEase(_startAnimationEase).From();
    }

    public void PlayAnimationByTrigger(AnimationType type)
    {
        _animationBase.PlayAnimationByTrigger(type);
    }

    #endregion

    protected virtual void Init()
    {
        ResetLife();
        if (_startWithBornAnimation) BornAnimation();
    }

    protected virtual void ResetLife()
    {
        _currentLife = _startLife;
    }

    protected virtual void Kill()
    {
        OnKill();
    }

    protected virtual void OnKill()
    {
        if (_collider != null) _collider.enabled = false;
        PlayAnimationByTrigger(AnimationType.DEATH);
        Destroy(gameObject, 3f);
    }

    public void Damage(float damage)
    {
        OnDamage(damage);
    }
}
