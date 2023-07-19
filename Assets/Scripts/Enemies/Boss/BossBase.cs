using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

public enum BossAction
{
    INIT,
    IDLE,
    WALK,
    ATTACK,
    DEATH
}

public class BossBase : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private float _startAnimationDuration = .5f;
    [SerializeField] private Ease _startAnimationEase = Ease.OutBack;

    [Header("Attack")]
    [SerializeField] private int _attackAmount = 5;
    [SerializeField] private float _timeBetweenAttacks = .5f;

    [Header("Movement")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private List<Transform> _waypoints;

    private StateMachine<BossAction> _stateMachine;
    private HealthBase _healthBase;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _stateMachine = new StateMachine<BossAction>();
        _stateMachine.RegisterState(BossAction.INIT, new BossStateInit());
        _stateMachine.RegisterState(BossAction.WALK, new BossStateWalk());
        _stateMachine.RegisterState(BossAction.ATTACK, new BossStateAttack());
        _stateMachine.RegisterState(BossAction.DEATH, new BossStateDeath());

        _healthBase = GetComponent<HealthBase>();
        _healthBase.OnKill += OnBossKill;
    }

    #region Attack

    public void StartAttack(Action endCallback = null)
    {
        StartCoroutine(AttackRoutine(endCallback));
    }

    private IEnumerator AttackRoutine(Action endCallback = null)
    {
        int attacks = 0;
        while (attacks < _attackAmount)
        {
            attacks++;
            transform.DOScale(1.1f, .1f).SetLoops(2, LoopType.Yoyo);
            yield return new WaitForSeconds(_timeBetweenAttacks);
        }

        endCallback?.Invoke();
    }

    #endregion

    #region Walk

    public void GoToRandomPoint(Action onArrive = null)
    {
        StartCoroutine(GoToPointRoutine(_waypoints[Random.Range(0, _waypoints.Count)], onArrive));
    }

    private IEnumerator GoToPointRoutine(Transform point, Action onArrive = null)
    {
        while (Vector3.Distance(transform.position, point.position) > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, Time.deltaTime * _speed);
            yield return new WaitForEndOfFrame();
        }

        onArrive?.Invoke();
    }

    #endregion

    #region Animation

    public void StartInitAnimation()
    {
        transform.DOScale(0, _startAnimationDuration).SetEase(_startAnimationEase).From();
    }

    #endregion

    #region Debug

    [Button]
    private void SwitchInit()
    {
        SwitchState(BossAction.INIT);
    }

    [Button]
    private void SwitchWalk()
    {
        SwitchState(BossAction.WALK);
    }

    [Button]
    private void SwithAttack()
    {
        SwitchState(BossAction.ATTACK);
    }

    #endregion

    #region State Machine
    public void SwitchState(BossAction state)
    {
        _stateMachine.SwitchState(state, this);
    }

    #endregion

    private void OnBossKill(HealthBase hb)
    {
        SwitchState(BossAction.DEATH);
    }
}
