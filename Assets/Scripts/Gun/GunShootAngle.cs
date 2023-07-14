using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootAngle : GunShootLimit
{
    [SerializeField] private int _amountPerShot = 4;
    [SerializeField] private float _angle = 15f;

    protected override void Shoot()
    {
        int multiplier = 0;

        for (int i = 0; i < _amountPerShot; i++)
        {
            if (i % 2 == 0)
            {
                multiplier++;
            }

            var projectile = Instantiate(_prefabProjectileBase, _positionToShoot);
            projectile.transform.localPosition = Vector3.zero;
            projectile.transform.localEulerAngles = Vector3.up * (i % 2 == 0 ? _angle : -_angle) * multiplier;

            projectile.Speed = _projectileSpeed;
            projectile.transform.parent = null;

        }
    }
}
