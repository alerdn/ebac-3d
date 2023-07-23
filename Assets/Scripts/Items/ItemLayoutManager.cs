using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLayoutManager : MonoBehaviour
{
    [SerializeField] private ItemLayout _layoutPrefab;
    [SerializeField] private Transform _container;

    private List<ItemLayout> _itemLayouts = new List<ItemLayout>();

    private void Start()
    {
        CreateItems();
    }

    private void CreateItems()
    {
        foreach (ItemSetup setup in ItemManager.Instance.ItemSetup)
        {
            ItemLayout layout = Instantiate(_layoutPrefab, _container);
            layout.Init(setup);

            _itemLayouts.Add(layout);
        }
    }
}
