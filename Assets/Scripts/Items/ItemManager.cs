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
    [SerializeField] private List<ItemSetup> _itemSetups;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        _itemSetups.ForEach(setup => setup.SOInt.Value = 0);
    }

    public void AddByType(ItemType itemType, int amount = 1)
    {
        if (amount < 0) return;

        _itemSetups.Find(setup => setup.ItemType == itemType).SOInt.Value += amount;
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
    public SOInt SOInt;
}