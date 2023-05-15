using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// Event raised when completing a level
    /// </summary>
    public static Action LoadNextLevel;
    
    public enum GameStates
    {
        GameStart,
        LevelLoaded,
        LevelCompleted
    }

    /// <summary>
    /// The Current State of our Game
    /// </summary>
    public GameStates GameState { get; set; }
    
    /// <summary>
    /// Stores the level completed index
    /// </summary>
    public int CurrentLevelCompleted { get; set; }

    protected override void Awake()
    {
        base.Awake();
        GameState = GameStates.GameStart;
    }

    /// <summary>
    /// Response to the levelcompleted event
    /// </summary>
    /// <param name="levelIndex"></param>
    private void LevelCompleted(int levelIndex)
    {
        CurrentLevelCompleted = levelIndex;
        GameState = GameStates.LevelCompleted;
        
        LoadNextLevel?.Invoke();
    }
    
    private void OnEnable()
    {
        CheckPoint.OnLevelCompleted += LevelCompleted;
    }

    private void OnDisable()
    {
        CheckPoint.OnLevelCompleted -= LevelCompleted;
    }
}
