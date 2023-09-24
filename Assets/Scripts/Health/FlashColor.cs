using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class FlashColor : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Color _color = Color.red;
    [SerializeField] private float _duration = .1f;
    [SerializeField] private string _colorParameter = "_EmissionColor";

    private Renderer _renderer;
    private Color _defaultColor;
    private Tween _currentTween;

    private void OnValidate()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        _defaultColor = _renderer.material.GetColor(_colorParameter);
    }

    [Button]
    public void Flash()
    {
        if (!_currentTween.IsActive())
            _currentTween = _renderer.material.DOColor(_color, _colorParameter, _duration).SetLoops(2, LoopType.Yoyo);
    }
}
