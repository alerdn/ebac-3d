using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _content;

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
                _content.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                _content.SetActive(false);
            }
        }
    }

    public void LoadLastSave()
    {
        LevelManager.Instance.LoadLevel(SaveManager.Instance.SaveSetup.LastLevel);
    }

    public void Save()
    {
        SaveManager.Instance.SaveAll(LevelManager.Instance.CurrentLevel);
        Notification.Instance.ShowNotification("Game saved", 2f);
    }

    public void SaveAndQuit()
    {
        LevelManager.Instance.SaveAndQuit();
    }
}
