using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelper : MonoBehaviour
{
    [SerializeField] private BossBase _boss;

    private bool _isBattleStarted;

    private void OnTriggerEnter(Collider other)
    {
        if (_isBattleStarted) return;

        if (other.transform.CompareTag("Player"))
        {
            _isBattleStarted = true;
            _boss.SwitchState(BossAction.INIT);
        }

    }
}
