using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilityShoot : PlayerAbilityBase
{
    [SerializeField] private GunBase _gun;

    protected override void Init()
    {
        base.Init();

        _inputs.Gameplay.Shoot.performed += (ctx) => StartShoot();
        _inputs.Gameplay.Shoot.canceled += (ctx) => StopShoot();
    }

    private void StartShoot()
    {
        _gun.StartShoot();
    }

    private void StopShoot()
    {
        _gun.StopShoot();
    }
}
