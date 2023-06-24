using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class HighScoreEntry
{
    public string playerName;
    public int score;
}

public class HighScoreManager : Singleton<HighScoreManager>
{
    private const string HighScoreKey = "HighScoresNew";
    private const int MaxHighScores = 5;
    private DateTime startTime;
    public int currentCoins = 0;

    private int lastScore = 0;

    public int CalculateScore() {
        var time = Timer.Instance.timeTaken();
        return (int)Mathf.Round(currentCoins / (time) * 10);
    }

    public void AddHighScore(int score)
    {

        string playerName = UIManager.Instance.nameValue;
        // Load existing high scores from PlayerPrefs
        List<HighScoreEntry> highScores = new List<HighScoreEntry>();
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            string raw = PlayerPrefs.GetString(HighScoreKey);
            highScores = StringToList(raw);
        }

        // Create a new HighScoreEntry and assign the player name and score
        HighScoreEntry newEntry = new HighScoreEntry
        {
            playerName = playerName,
            score = score
        };

        // Add the new entry to the list
        highScores.Add(newEntry);

        // Sort the high scores in descending order
        highScores.Sort((a, b) => b.score.CompareTo(a.score));

        // Keep only the top 5 high scores
        if (highScores.Count > MaxHighScores)
        {
            highScores = highScores.GetRange(0, MaxHighScores);
        }

        // Save the updated high scores to PlayerPrefs
        string highScoreString = ListToString(highScores);
        PlayerPrefs.SetString(HighScoreKey, highScoreString);
    }

    private List<HighScoreEntry> StringToList(string value)
    {
        string[] entryStrings = value.Split(';');
        List<HighScoreEntry> entries = new List<HighScoreEntry>();
        foreach (string entryString in entryStrings)
        {
            string[] entryData = entryString.Split(',');
            if (entryData.Length == 2)
            {
                string playerName = entryData[0];
                int score;
                if (int.TryParse(entryData[1], out score))
                {
                    HighScoreEntry entry = new HighScoreEntry
                    {
                        playerName = playerName,
                        score = score
                    };
                    entries.Add(entry);
                }
            }
        }
        return entries;
    }

    private string ListToString(List<HighScoreEntry> list)
    {
        string value = string.Empty;
        for (int i = 0; i < list.Count; i++)
        {
            value += list[i].playerName + "," + list[i].score.ToString();
            if (i < list.Count - 1)
            {
                value += ";";
            }
        }
        return value;
    }

    public void SetStartTime()
    {
        startTime = DateTime.Now;
    }

    public List<HighScoreEntry> GetHighScores()
    {
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            string raw = PlayerPrefs.GetString(HighScoreKey);
            return StringToList(raw);
        }
        else
        {
            return new List<HighScoreEntry>();
        }
    }

    public void UpdateLastScore()
    {
        this.lastScore = CalculateScore();

        if(GameManager.Instance.CurrentLevelCompleted == 2)
        {
            AddHighScore(this.lastScore);
        }
    }
    public int GetLastScore()
    {
        return lastScore;
    }
}
