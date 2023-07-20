using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HealthEnemy : HealthBase
{
    [SerializeField] private FlashColor _flashColor;
    [SerializeField] private ParticleSystem _particles;

    public override void Damage(float damage)
    {
        if (_flashColor != null) _flashColor.Flash();
        if (_particles != null) _particles.Emit(15);

        base.Damage(damage);
    }
}
