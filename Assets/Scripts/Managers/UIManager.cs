using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")] 
    [SerializeField] private Image fuelImage;
    [SerializeField] private GameObject[] playerLifes;

    [Header("Coins")] 
    [SerializeField] private TextMeshProUGUI coinTMP;
    
    private float _currentJetpackFuel;
    private float _jetpackFuel;
    
    private void Update()
    {
        InternalJetpackUpdate();    
        UpdateCoins();
    }

    /// <summary>
    /// Gets the fuel values
    /// </summary>
    /// <param name="currentFuel"></param>
    /// <param name="maxFuel"></param>
    public void UpdateFuel(float currentFuel, float maxFuel)
    {
        _currentJetpackFuel = currentFuel;
        _jetpackFuel = maxFuel;
    }

    /// <summary>
    /// Updates the jetpack fuel
    /// </summary>
    private void InternalJetpackUpdate()
    {
        fuelImage.fillAmount =
            Mathf.Lerp(fuelImage.fillAmount, _currentJetpackFuel / _jetpackFuel, Time.deltaTime * 10f);
    }

    /// <summary>
    /// Updates the coins
    /// </summary>
    private void UpdateCoins()
    {
        coinTMP.text = CoinManager.Instance.TotalCoins.ToString();
    }
    
    /// <summary>
    /// Updates the player lifes
    /// </summary>
    /// <param name="currentLifes"></param>
    private void OnPlayerLifes(int currentLifes)
    {
        for (int i = 0; i < playerLifes.Length; i++)
        {
            if (i < currentLifes) // 2
            {
                playerLifes[i].gameObject.SetActive(true);
            }
            else
            {
                playerLifes[i].gameObject.SetActive(false);
            }
        }
    }
    
    private void OnEnable()
    {
        Health.OnLifesChanged += OnPlayerLifes;
    }

    private void OnDisable()
    {
        Health.OnLifesChanged -= OnPlayerLifes;
    }
}
