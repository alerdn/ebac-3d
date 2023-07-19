using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }

    public StateMachine<GameState> StateMachine { get; private set; }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        
    }
}
