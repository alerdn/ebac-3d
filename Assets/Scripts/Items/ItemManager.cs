using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public enum ItemType
{
    COIN,
    LIFE_PACK
}

public class ItemManager : Singleton<ItemManager>
{
    public List<ItemSetup> ItemSetup => _itemSetups;

    [SerializeField] private List<ItemSetup> _itemSetups;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        _itemSetups.ForEach(setup => setup.SOInt.Value = 0);
    }

    public ItemSetup GetSetupByType(ItemType itemType)
    {
        return _itemSetups.Find(setup => setup.ItemType == itemType);
    }

    public void AddByType(ItemType itemType, int amount = 1)
    {
        if (amount < 0) return;

        _itemSetups.Find(setup => setup.ItemType == itemType).SOInt.Value += amount;
    }

    public void SetByType(ItemType itemType, int amount)
    {
        if (amount < 0) return;

        _itemSetups.Find(setup => setup.ItemType == itemType).SOInt.Value = amount;
    }

    public void RemoveByType(ItemType itemType, int amount = 1)
    {
        if (amount < 0) return;

        ItemSetup setup = _itemSetups.Find(setup => setup.ItemType == itemType);
        setup.SOInt.Value -= amount;

        if (setup.SOInt.Value < 0) setup.SOInt.Value = 0;
    }
}

[Serializable]
public class ItemSetup
{
    public ItemType ItemType;
    public Sprite Sprite;
    public SOInt SOInt;
    public bool IsUseable;
    public string Key;
}