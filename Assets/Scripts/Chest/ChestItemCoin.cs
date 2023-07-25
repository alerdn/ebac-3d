using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestItemCoin : ChestItemBase
{
    [SerializeField] private int _coinNumber = 5;
    [SerializeField] private GameObject _coinObject;
    [SerializeField] private Vector2 _randomSpawnPosition;
    [SerializeField] private float _collectAnimationDuration = .5f;

    private List<GameObject> _coins = new List<GameObject>();

    public override void Collect()
    {
        foreach (GameObject coin in _coins)
        {
            coin.transform.DOMoveY(2f, _collectAnimationDuration).SetRelative();
            coin.transform.DOScale(0, _collectAnimationDuration / 2).SetDelay(_collectAnimationDuration / 2);
            ItemManager.Instance.AddByType(ItemType.COIN);
        }
    }

    public override void ShowItem()
    {
        CreateItems();
    }

    private void CreateItems()
    {
        for (int i = 0; i < _coinNumber; i++)
        {
            GameObject coin = Instantiate(_coinObject);
            coin.transform.position = Vector3.forward * Random.Range(_randomSpawnPosition.x, _randomSpawnPosition.y)
                + Vector3.right * Random.Range(_randomSpawnPosition.x, _randomSpawnPosition.y)
                + transform.position;
            coin.transform.DOScale(0, .1f).SetEase(Ease.OutBack).From();
            _coins.Add(coin);
        }
    }
}
