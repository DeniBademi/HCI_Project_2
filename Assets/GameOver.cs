﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private CoinManager coins;
    private Timer timer;
    private LevelManager level;
    public TMP_Text score;
    public int finalScore { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int TimeCalculator(){
        timer = FindObjectOfType<Timer>();
        float timePoints = timer.timeTaken();
        int minutes = (int)(timePoints / 60f);
        int seconds = (int)(timePoints % 60f);
        int timeScore = minutes * 100 + seconds;
        return timeScore;
    }

    public void EndGameLogic(){
        int timeScore = TimeCalculator();

        coins = FindObjectOfType<CoinManager>();
        int numCoins = CoinManager.Instance.TotalCoins;


        HighScoreManager.Instance.UpdateLastScore();
        score.text = "Score: " + HighScoreManager.Instance.GetLastScore().ToString();
        //Debug.Log(finalScore);
        coins.ResetCoins();
    }
}
