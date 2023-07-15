using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootLimit : GunBase
{
    [SerializeField] private float _maxShoot = 5f;
    [SerializeField] private float _timeToRecharge = 1f;

    private float _currentShoots;
    private bool _isRecharging;

    protected override IEnumerator ShootRoutine()
    {
        while (true)
        {
            // Shoot();
            // yield return new WaitForSeconds(timeBetweenShoot);

            if (_isRecharging) yield break;

            if (_currentShoots < _maxShoot)
            {
                Shoot();
                _currentShoots++;
                CheckRecharge();
                UpdateUI(_maxShoot, _currentShoots);
                yield return new WaitForSeconds(_timeBetweenShoot);
            }
        }
    }

    private void CheckRecharge()
    {
        if (_currentShoots >= _maxShoot)
        {
            StopShoot();
            StartRecharge();
        }
    }

    private void StartRecharge()
    {
        _isRecharging = true;
        StartCoroutine(RechargeRoutine());
    }

    private IEnumerator RechargeRoutine()
    {
        float time = 0f;
        while (time < _timeToRecharge)
        {
            time += Time.deltaTime;
            UpdateUI(time / _timeToRecharge);
            yield return new WaitForEndOfFrame();
        }
        _currentShoots = 0;
        _isRecharging = false;
    }

    private void UpdateUI(float value)
    {
        if (UiUpdater != null) UiUpdater.UpdateValue(value);
    }

    private void UpdateUI(float max, float current)
    {
        if (UiUpdater != null) UiUpdater.UpdateValue(max, current);
    }
}
