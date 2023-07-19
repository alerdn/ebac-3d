using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkNShoot : EnemyBase
{
    [Header("Waypoints")]
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _minDistance = 1f;
    [SerializeField] private float _speed = 1f;

    [Header("Gun")]
    [SerializeField] private GunBase _gun;
    [SerializeField] private int _minDistanceToShoot = 10;

    private int _index = 0;
    private bool _canWalk = true;
    private bool _isShooting;

    protected override void Update()
    {
        base.Update();

        if (!_canWalk) return;

        if (Vector3.Distance(transform.position, _waypoints[_index].position) < _minDistance)
        {
            _index++;
            if (_index >= _waypoints.Length)
            {
                _index = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_index].position, Time.deltaTime * _speed);

        if (!_isShooting && Vector3.Distance(transform.position, player.transform.position) < _minDistanceToShoot)
        {
            _isShooting = true;
            _gun.StartShoot();
        }
    }

    protected override void OnKill()
    {
        _canWalk = false;
        _gun.StopShoot();
        base.OnKill();
    }
}
