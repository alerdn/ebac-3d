using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenuHelper : MonoBehaviour
{
    private void Start()
    {
        SaveManager.Instance.OnSaveLoaded += SaveLoaded;
        SaveManager.Instance.Load();
    }

    private void SaveLoaded(SaveSetup setup)
    {
        LevelManager.Instance.LoadMenu();
    }
}
