using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCoin : Collectable
{
    [Header("Settings")] 
    [SerializeField] private int amountToAdd = 10;
    
    protected override void Collect()
    {
        AddCoin();
    }

    /// <summary>
    /// Adds coins to our Global counter
    /// </summary>
    private void AddCoin()
    {
        CoinManager.Instance.AddCoins(amountToAdd);
        Debug.Log("Coin Added");
    }
}
