using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public int CurrentLevel = 0;

    [SerializeField] private GameObject _loadingScreen;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(int level)
    {
        CurrentLevel = level;
        SceneManager.LoadScene("SCN_Game_" + level);
        _loadingScreen.SetActive(true);

        IEnumerator CheckLoad()
        {
            yield return new WaitForSeconds(1f);

            SaveSetup setup = SaveManager.Instance.SaveSetup;

            // Set checkpoints
            CheckpointManager.Instance.SaveCheckpoint(setup.LastCheckpointKey);

            // Set items
            ItemManager.Instance.SetByType(ItemType.COIN, setup.Coins);
            ItemManager.Instance.SetByType(ItemType.LIFE_PACK, setup.LifePacks);

            // Respawn at checkpoint and set details
            Player.Instance.Respawn();
            Player.Instance.ClothChanger.SetTexture(setup.PlayerCurrentTexture);
            Debug.Log(setup.PlayerCurrentLife);
            if (setup.PlayerCurrentLife > 0f)
                Player.Instance.Health.CurrentLife = setup.PlayerCurrentLife;

            _loadingScreen.SetActive(false);
        }
        StartCoroutine(CheckLoad());

        SaveManager.Instance.SaveLevel(level);
    }

    public void SaveAndQuit()
    {
        SaveManager.Instance.SaveAll(CurrentLevel);
        LoadMenu();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("SCN_Menu");
    }
}
