using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    [SerializeField] private float _minDistanceToCollect = .2f;
    [SerializeField] private float _itemSpeed = 3f;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) > _minDistanceToCollect)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, Time.deltaTime * _itemSpeed);
            _itemSpeed++;
        }
    }
}
