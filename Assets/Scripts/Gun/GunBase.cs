using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [SerializeField] protected ProjectileBase _prefabProjectileBase;
    [SerializeField] protected Transform _positionToShoot;
    [SerializeField] protected float _timeBetweenShoot = .3f;
    [SerializeField] protected float _projectileSpeed = 50f;

    private Coroutine _shootRoutine;
    private Player _player;

    public void StartShoot()
    {
        StopShoot();
        _shootRoutine = StartCoroutine(ShootRoutine());
    }

    public void StopShoot()
    {
        if (_shootRoutine != null)
        {
            StopCoroutine(_shootRoutine);
        }
    }

    protected virtual IEnumerator ShootRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_timeBetweenShoot);
        }
    }

    protected virtual void Shoot()
    {
        var projectile = Instantiate(_prefabProjectileBase);
        projectile.transform.position = _positionToShoot.position;
        projectile.transform.SetPositionAndRotation(_positionToShoot.position, _positionToShoot.rotation);
        projectile.speed = _projectileSpeed;
    }
}
