using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelHelper : MonoBehaviour
{
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _nextLevel;

    public void EndLevel()
    {
        SaveManager.Instance.SaveAll(_currentLevel);
        Invoke(nameof(LoadNextLevel), 2f);
    }

    private void LoadNextLevel()
    {
        LevelManager.Instance.LoadLevel(_nextLevel);
    }
}
