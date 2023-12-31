using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossStateBase : StateBase
{
    protected BossBase boss;

    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        boss = (BossBase)objs[0];
    }
}

public class BossStateInit : BossStateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        boss.StartInitAnimation(OnInit);
    }

    private void OnInit()
    {
        boss.SwitchState(BossAction.ATTACK);
    }
}

public class BossStateWalk : BossStateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        boss.GoToRandomPoint(OnArrive);
    }

    private void OnArrive()
    {
        boss.SwitchState(BossAction.ATTACK);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        boss.StopAllCoroutines();
    }
}

public class BossStateAttack : BossStateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        boss.StartAttack(EndAttack);
    }

    private void EndAttack()
    {
        boss.SwitchState(BossAction.WALK);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        boss.StopAllCoroutines();
    }
}

public class BossStateDeath : BossStateBase
{
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(objs);
        boss.transform.localScale = Vector3.one * .2f;
    }
}