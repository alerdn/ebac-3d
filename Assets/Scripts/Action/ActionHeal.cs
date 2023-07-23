using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHeal : ActionBase
{
    protected override void StartInputs()
    {
        base.StartInputs();
        inputs.Gameplay.Heal.performed += (ctx) => Heal();
    }

    private void Heal()
    {
        if (itemSetup.SOInt.Value > 0)
        {
            ItemManager.Instance.RemoveByType(itemType);
            Player.Instance.Health.ResetLife();
        }
    }
}
