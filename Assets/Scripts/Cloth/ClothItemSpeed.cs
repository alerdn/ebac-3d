using UnityEngine;

public class ClothItemSpeed : ClothItemBase
{
    [SerializeField] private float _targetSpeed = 2f;

    public override void Collect()
    {
        base.Collect();
        Player.Instance.ChangeSpeed(_targetSpeed, duration);
    }
}
