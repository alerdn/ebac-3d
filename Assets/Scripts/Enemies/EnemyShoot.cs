using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : EnemyBase
{
    [SerializeField] private GunBase _gun;
    [SerializeField] private int _minDistanceToShoot = 10;

    private bool _isShooting;

    protected override void Update()
    {
        base.Update();
        if (!_isShooting && Vector3.Distance(transform.position, player.transform.position) < _minDistanceToShoot)
        {
            _isShooting = true;
            _gun.StartShoot();
        }
    }

    protected override void OnKill()
    {
        _gun.StopShoot();
        base.OnKill();
    }
}
