using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemLayout : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _counter;

    [Header("Action Setup")]
    [SerializeField] private GameObject _actionKeyDisplay;
    [SerializeField] private TMP_Text _keyText;

    private ItemSetup _setup;

    public void Init(ItemSetup setup)
    {
        _setup = setup;
        _setup.SOInt.OnUpdate += UpdateUI;
        _icon.sprite = _setup.Sprite;

        _actionKeyDisplay.SetActive(_setup.IsUseable);
        _keyText.text = _setup.Key;
    }

    private void UpdateUI(int newCounter)
    {
        _counter.text = newCounter.ToString();
    }
}
