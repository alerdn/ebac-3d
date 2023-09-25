using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

public class SaveManager : Singleton<SaveManager>
{
    public event Action<SaveSetup> OnSaveLoaded;

    public SaveSetup SaveSetup => _saveSetup;

    private SaveSetup _saveSetup;
    private string _path;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        _path = Application.persistentDataPath + "/save.json";
    }

    public void Save()
    {
        string setupToJson = JsonUtility.ToJson(_saveSetup);
        SaveFile(setupToJson);
    }

    public void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        Save();
    }

    public void Load()
    {
        string fileLoaded = "";

        if (File.Exists(_path))
        {
            fileLoaded = File.ReadAllText(_path);
            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
        }
        else
        {
            CreateNewSave();
        }

        OnSaveLoaded?.Invoke(_saveSetup);
    }

    #region SAVE

    public void SaveLevel(int lastLevel, bool saveInFile = true)
    {
        _saveSetup.LastLevel = lastLevel;
        if (saveInFile) Save();
    }

    public void SaveItems(bool saveInFile = true)
    {
        _saveSetup.Coins = ItemManager.Instance.GetSetupByType(ItemType.COIN).SOInt.Value;
        _saveSetup.LifePacks = ItemManager.Instance.GetSetupByType(ItemType.LIFE_PACK).SOInt.Value;
        if (saveInFile) Save();
    }

    public void SaveCheckpoints(bool saveInFile = true)
    {
        _saveSetup.LastCheckpointKey = CheckpointManager.Instance.LastCheckpointKey;
        _saveSetup.BeforeLastCheckpointKey = CheckpointManager.Instance.BeforeLastCheckpointKey;
        if (saveInFile) Save();
    }

    public void SavePlayerDetails(bool saveInFile = true)
    {
        _saveSetup.PlayerCurrentLife = Player.Instance.Health.CurrentLife;
        _saveSetup.PlayerCurrentTexture = Player.Instance.ClothChanger.CurrentTexture;
        if (saveInFile) Save();
    }

    public void SaveAll(int level)
    {
        SaveLevel(level, false);
        SaveItems(false);
        SaveCheckpoints(false);
        SavePlayerDetails(false);
        Save();
    }

    #endregion

    private void SaveFile(string json)
    {
        File.WriteAllText(_path, json);
    }
}

[System.Serializable]
public class SaveSetup
{
    public float PlayerCurrentLife;
    public Texture PlayerCurrentTexture;
    public int LastLevel;
    public int Coins;
    public int LifePacks;
    public int LastCheckpointKey;
    public int BeforeLastCheckpointKey;
}