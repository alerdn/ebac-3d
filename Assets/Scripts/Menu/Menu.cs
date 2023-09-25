using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text _playButtonText;
    [SerializeField] private GameObject _buttonsGrid;

    private void Awake()
    {
        _buttonsGrid.transform.localScale = Vector3.zero;
    }

    private void Start()
    {
        LoadMenu(SaveManager.Instance.SaveSetup);
    }

    private void LoadMenu(SaveSetup setup)
    {
        if (SaveManager.Instance.SaveSetup.LastLevel == 0)
        {
            _playButtonText.text = "Play";
        }
        else
        {
            _playButtonText.text = "Continue";
        }

        _buttonsGrid.transform.DOScale(1, 1f);
    }

    public void Play()
    {
        int lastLevel = SaveManager.Instance.SaveSetup.LastLevel;
        LevelManager.Instance.LoadLevel(lastLevel == 0 ? 1 : lastLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
