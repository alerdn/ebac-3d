using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : EnemyBase
{
    [SerializeField] private GunBase _gun;

    protected override void Init()
    {
        base.Init();

        _gun.StartShoot();
    }
}
