using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableItemBase : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Transform _dropPosition;
    [SerializeField] private int _itemDropAmount = 10;
    [SerializeField] private GameObject _itemPrefab;

    private HealthBase _healthBase;
    private Tween _shakeTween;
    private int _itemsLeft;

    private void Start()
    {
        _healthBase = GetComponent<HealthBase>();
        _healthBase.OnDamage += OnDamage;
        _healthBase.OnKill += DropItemGroup;
    }

    private void OnDamage(HealthBase hb)
    {
        if (_shakeTween == null)
        {
            _shakeTween = transform.DOShakeScale(.1f, Vector3.up / 3, 1).OnComplete(() => _shakeTween = null);
        }
        DropItem();
    }

    private void DropItem()
    {
        if (_itemDropAmount > 0)
        {
            _itemDropAmount--;
            GameObject item = Instantiate(_itemPrefab);
            item.transform.position = _dropPosition.position;
            item.transform.DOScale(0, 1f).SetEase(Ease.OutBack).From();
        }
    }

    private void DropItemGroup(HealthBase hb)
    {
        for (int i = 0; i < _itemDropAmount; i++)
        {
            DropItem();
        }
    }
}
