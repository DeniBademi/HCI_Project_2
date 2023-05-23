﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public static Action<PlayerMotor> OnPlayerSpawn;

    public GameObject pauseMenu;
    public Timer timer;

    [Header("Settings")]
    [SerializeField] private Transform levelStartPoint;
    [SerializeField] private GameObject playerPrefab;

    [Header("Levels")] 
    [SerializeField] private int startingLevel = 0;
    [SerializeField] private Level[] levels;
    
    private int startingSceneIndex;
    private PlayerMotor _currentPlayer;
    private int _nextLevel;

    private void Awake()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
        InitLevel(startingLevel);
        SpawnPlayer(playerPrefab, levels[startingLevel].SpawnPoint);
        pauseMenu.SetActive(false);
    }

    private void Start()
    {
        // Call Event
        OnPlayerSpawn?.Invoke(_currentPlayer);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RevivePlayer();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            bool isPaused = !pauseMenu.activeSelf;

            if(isPaused)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void ContinueButton() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void QuitButton() {
        Time.timeScale = 1f;
        timer.ResetTimer();
        Destroy(Timer.Instance.gameObject);
        SceneManager.LoadScene(startingSceneIndex);
    }

    private void InitLevel(int levelIndex)
    {
        foreach (Level level in levels)
        {
            level.gameObject.SetActive(false);
        }
        
        if(levels.Length > levelIndex)
            levels[levelIndex].gameObject.SetActive(true);
        else
        {
            //GameManager.Instance.GameState = GameManager.GameStates.GameOver;
            var score = HighScoreManager.Instance.CalculateScore();
            Debug.Log("Score: " + score);
            HighScoreManager.Instance.AddHighScore(score);
        }
    }
    
    /// <summary>
    /// Spawns our player in the spawnPoint
    /// </summary>
    /// <param name="player"></param>
    /// <param name="spawnPoint"></param>
    private void SpawnPlayer(GameObject player, Transform spawnPoint)
    {
        if (player != null)
        {
            _currentPlayer = Instantiate(player, spawnPoint.position, Quaternion.identity).GetComponent<PlayerMotor>();
            _currentPlayer.GetComponent<Health>().ResetLife();
        }
    }
    
    /// <summary>
    /// Revives our player
    /// </summary>
    private void RevivePlayer()
    {
        if (_currentPlayer != null)
        {
            _currentPlayer.gameObject.SetActive(true);
            _currentPlayer.SpawnPlayer(levelStartPoint);
            _currentPlayer.GetComponent<Health>().ResetLife();
            _currentPlayer.GetComponent<Health>().Revive();
        }
    }
    
    private void PlayerDeath(PlayerMotor player)
    {
        _currentPlayer.gameObject.SetActive(false);
    }
    
    private void MovePlayerToStartPosition(Transform newSpawnPoint)
    {
        if (_currentPlayer != null)
        {
            _currentPlayer.transform.position = new Vector3(newSpawnPoint.position.x, newSpawnPoint.position.y, 0f);
        }
    }

    private void LoadLevel()
    {
        GameManager.Instance.GameState = GameManager.GameStates.LevelLoaded;
        _nextLevel = GameManager.Instance.CurrentLevelCompleted + 1;
        InitLevel(_nextLevel);
        MovePlayerToStartPosition(levels[_nextLevel].SpawnPoint);
    }
    
    private void OnEnable()
    {
        Health.OnDeath += PlayerDeath;
        GameManager.LoadNextLevel += LoadLevel;
    }

    private void OnDisable()
    {
        Health.OnDeath -= PlayerDeath;
        GameManager.LoadNextLevel -= LoadLevel;
    }
}
