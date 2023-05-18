using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : Singleton<HighScoreManager>
{


    private const string HighScoreKey = "HighScores";
    private const int MaxHighScores = 5;
    private DateTime startTime;

    public int CalculateScore() {
        var time = (DateTime.Now - startTime).TotalSeconds;
        return CoinManager.Instance.TotalCoins / ((int)time / 10);
    }

    public void AddHighScore(int score)
    {

        // Load existing high scores from PlayerPrefs
        List<int> highScores = new List<int>();
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            string raw = PlayerPrefs.GetString(HighScoreKey);
            highScores = StringToList(raw);
        }

        // Add the new score to the list
        highScores.Add(score);

        // Sort the high scores in descending order
        highScores.Sort((a, b) => b.CompareTo(a));

        // Keep only the top 5 high scores
        if (highScores.Count > MaxHighScores)
        {
            highScores = highScores.GetRange(0, MaxHighScores);
        }

        // Save the updated high scores to PlayerPrefs
        string highScoreString = ListToString(highScores);
        PlayerPrefs.SetString(HighScoreKey, highScoreString);
        PlayerPrefs.Save();
    }

    private List<int> StringToList(string value)
    {
        string[] scoreStrings = value.Split(',');
        List<int> scores = new List<int>();
        foreach (string scoreString in scoreStrings)
        {
            int score;
            if (int.TryParse(scoreString, out score))
            {
                scores.Add(score);
            }
        }
        return scores;
    }

    private string ListToString(List<int> list)
    {
        string value = string.Empty;
        for (int i = 0; i < list.Count; i++)
        {
            value += list[i].ToString();
            if (i < list.Count - 1)
            {
                value += ",";
            }
        }
        return value;
    }

    public void SetStartTime()
    {
        startTime = DateTime.Now;
    }
}
