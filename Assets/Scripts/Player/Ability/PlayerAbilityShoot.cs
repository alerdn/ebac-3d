using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilityShoot : PlayerAbilityBase
{
    [SerializeField] private GunBase _gun;
    [SerializeField] private Transform _gunHolder;

    private GunBase _currentGun;

    protected override void Init()
    {
        base.Init();

        SpawnGun();

        _inputs.Gameplay.Shoot.performed += (ctx) => StartShoot();
        _inputs.Gameplay.Shoot.canceled += (ctx) => StopShoot();
    }

    private void SpawnGun()
    {
        _currentGun = Instantiate(_gun, _gunHolder);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
    }

    private void StopShoot()
    {
        _currentGun.StopShoot();
    }
}
