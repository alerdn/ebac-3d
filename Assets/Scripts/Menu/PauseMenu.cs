using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _content;

    [Header("Audio")]
    [SerializeField] private TMP_Text _textMusicToggle;
    [SerializeField] private TMP_Text _textSFXToggle;

    private void Start()
    {
        _content.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!_content.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                _content.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _content.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void LoadLastSave()
    {
        Time.timeScale = 1;
        LevelManager.Instance.LoadLevel(SaveManager.Instance.SaveSetup.LastLevel);
    }

    public void Save()
    {
        SaveManager.Instance.SaveAll(LevelManager.Instance.CurrentLevel);
        Notification.Instance.ShowNotification("Game saved", 2f);
    }

    public void SaveAndQuit()
    {
        Time.timeScale = 1;
        LevelManager.Instance.SaveAndQuit();
    }

    public void ToggleMusic()
    {
        bool isMusicOn = AudioManager.Instance.ToggleMusic();
        _textMusicToggle.text = isMusicOn ? "ON" : "OFF";
    }

    public void ToggleSFX()
    {
        bool isSFXOn = AudioManager.Instance.ToggleSFX();
        _textSFXToggle.text = isSFXOn ? "ON" : "OFF";
    }
}
