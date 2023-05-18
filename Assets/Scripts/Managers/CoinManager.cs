using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : Singleton<CoinManager>
{
    /// <summary>
    /// Control of the coins we have
    /// </summary>
    public int TotalCoins { get; set; }

    private string COINS_KEY = "MyGame_TOTAL_COINS";

    private void Start()
    {
        LoadCoins();
    }

    /// <summary>
    /// Load the coins saved
    /// </summary>
    private void LoadCoins()
    {
        TotalCoins = PlayerPrefs.GetInt(COINS_KEY, 0);
    }
    
    /// <summary>
    /// Adds coins to our Global
    /// </summary>
    /// <param name="amount"></param>
    public void AddCoins(int amount)
    {
        TotalCoins += amount;
        
        PlayerPrefs.SetInt(COINS_KEY, TotalCoins);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Removes coins from our total
    /// </summary>
    /// <param name="amount"></param>
    public void RemoveCoins(int amount)
    {
        TotalCoins -= amount;
        
        PlayerPrefs.SetInt(COINS_KEY, TotalCoins);
        PlayerPrefs.Save();
    }
    public void ResetCoins()
    {
        TotalCoins = 0;
        PlayerPrefs.SetInt(COINS_KEY, TotalCoins);
        PlayerPrefs.Save();
    }
}
