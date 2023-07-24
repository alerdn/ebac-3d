using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class ChestBase : MonoBehaviour
{
    [SerializeField] private GameObject _notification;
    [SerializeField] private float _notificationScaleDuration = .2f;
    [SerializeField] private Ease _notificationScaleEase = Ease.OutBack;

    private Animator _animator;
    private float _notificationScale;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _notificationScale = _notification.transform.localScale.x;
        HideNotification();
    }

    [Button]
    private void OpenChest()
    {
        _animator.SetTrigger("Open");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            ShowNotification();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            HideNotification();
        }
    }

    private void ShowNotification()
    {
        _notification.transform.DOScale(_notificationScale, _notificationScaleDuration).SetEase(_notificationScaleEase);
    }

    private void HideNotification()
    {
        _notification.transform.localScale = Vector3.zero;
    }
}
