using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ChestBase : MonoBehaviour
{
    public UnityEvent _OnChestOpened;

    [SerializeField] private ChestItemBase _chestItem;

    [Header("Notification")]
    [SerializeField] private GameObject _notification;
    [SerializeField] private float _notificationScaleDuration = .2f;
    [SerializeField] private Ease _notificationScaleEase = Ease.OutBack;

    private Inputs _inputs;
    private Animator _animator;
    private float _notificationScale;
    private bool _isChestOpened;
    private bool _canOpenChest;

    private void OnEnable()
    {
        if (_inputs != null) _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _notificationScale = _notification.transform.localScale.x;
        StartInputs();
        HideNotification();
    }

    private void StartInputs()
    {
        _inputs = new Inputs();
        _inputs.Enable();
        _inputs.Gameplay.Interact.performed += (ctx) => OpenChest();
    }

    private void OpenChest()
    {
        if (!_isChestOpened && _canOpenChest)
        {
            _animator.SetTrigger("Open");
            _isChestOpened = true;
            HideNotification();
            Invoke(nameof(ShowItem), .5f);
            _OnChestOpened?.Invoke();
        }
    }

    private void ShowItem()
    {
        _chestItem.ShowItem();
        Invoke(nameof(CollectItem), .25f);
    }

    private void CollectItem()
    {
        _chestItem.Collect();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (!_isChestOpened) ShowNotification();
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
        _canOpenChest = true;
    }

    private void HideNotification()
    {
        _notification.transform.localScale = Vector3.zero;
        _canOpenChest = false;
    }
}
