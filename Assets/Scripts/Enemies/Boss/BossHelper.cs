using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossHelper : MonoBehaviour
{
    [SerializeField] private BossBase _boss;
    [SerializeField] private CinemachineVirtualCamera _camera;

    private bool _isBattleStarted;

    private void Start()
    {
        TurnCamera(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isBattleStarted) return;

        if (other.transform.CompareTag("Player"))
        {
            _isBattleStarted = true;
            _boss.SwitchState(BossAction.INIT);

            Notification.Instance.ShowNotification("uma mega slime surgiu!!!", 3f);
            TurnCamera(true);
        }
    }

    private void TurnCamera(bool enabled)
    {
        _camera.enabled = enabled;
    }
}
