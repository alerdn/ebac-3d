using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothItemStrong : ClothItemBase
{
    [SerializeField] private float _targetDamageMultiplier = .5f;

    public override void Collect()
    {
        base.Collect();
        Player.Instance.Health.ChangeDamageMultiplier(_targetDamageMultiplier, duration);
    }
}
