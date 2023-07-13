using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilityShoot : PlayerAbilityBase
{
    [SerializeField] private UIGunUpdater _uiGunUpdater;
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
        _inputs.Gameplay.SelectPrimaryGun.performed += (ctx) => ChangeGun(0);
        _inputs.Gameplay.SelectSecondaryGun.performed += (ctx) => ChangeGun(1);
    }

    private void SpawnGun()
    {
        _currentGun = Instantiate(_guns[_currentGunIndex], _gunHolder);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
        _currentGun.UiUpdater = _uiGunUpdater;
        _currentGun.UiUpdater.UpdateValue(1f);
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

    private void ChangeGun(int index)
    {
        if (index == _currentGunIndex) return;

        _currentGunIndex = index;
        if (_currentGun != null) Destroy(_currentGun.gameObject);
        SpawnGun();
    }
}
