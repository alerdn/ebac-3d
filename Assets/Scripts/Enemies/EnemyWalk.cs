using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : EnemyBase
{
    [Header("Waypoints")]
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _minDistance = 1f;
    [SerializeField] private float _speed = 1f;

    private int _index = 0;

    private void Update()
    {
        if (Vector3.Distance(transform.position, _waypoints[_index].position) < _minDistance)
        {
            _index++;
            if (_index >= _waypoints.Length)
            {
                _index = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_index].position, Time.deltaTime * _speed);
        transform.LookAt(_waypoints[_index].position);
    }


}
