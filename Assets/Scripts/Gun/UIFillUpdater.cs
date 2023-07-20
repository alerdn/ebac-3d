using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIFillUpdater : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private float _duration = .1f;
    [SerializeField] private Ease _ease = Ease.OutBack;

    private Image uiImage;
    private Tween _currentTween;

    private void Awake()
    {
        uiImage = GetComponent<Image>();
    }

    public void UpdateValue(float f)
    {
        uiImage.fillAmount = f;
    }

    public void UpdateValue(float max, float current)
    {
        if (_currentTween != null) _currentTween.Kill();
        _currentTween = uiImage.DOFillAmount(1 - (current / max), _duration).SetEase(_ease);
    }
}
