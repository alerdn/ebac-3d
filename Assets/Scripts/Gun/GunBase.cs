using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public UIFillUpdater UiUpdater;

    [SerializeField] private SFXType _sfxType;
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
        PlaySfx();
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
        projectile.Speed = _projectileSpeed;
    }

    private void PlaySfx()
    {
        SFXPool.Instance.Play(_sfxType);
    }
}
