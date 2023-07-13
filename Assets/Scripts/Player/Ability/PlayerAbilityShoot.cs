using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilityShoot : PlayerAbilityBase
{
    [SerializeField] private List<GunBase> _guns;
    [SerializeField] private Transform _gunHolder;

    [SerializeField] private GunBase _currentGun;
    [SerializeField] private int _currentGunIndex;

    protected override void Init()
    {
        base.Init();

        SpawnGun();

        _inputs.Gameplay.Shoot.performed += (ctx) => StartShoot();
        _inputs.Gameplay.Shoot.canceled += (ctx) => StopShoot();

        _inputs.Gameplay.ChangeGun.performed += (ctx) => ChangeGun();
    }

    private void SpawnGun()
    {
        _currentGun = Instantiate(_guns[_currentGunIndex], _gunHolder);
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

    private void ChangeGun()
    {
        _currentGunIndex = _currentGunIndex++ < _guns.Count - 1 ? _currentGunIndex : 0;
        if (_currentGun != null) Destroy(_currentGun.gameObject);
        SpawnGun();
    }
}
