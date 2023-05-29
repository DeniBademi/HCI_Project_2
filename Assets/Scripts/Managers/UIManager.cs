using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")] 
    [SerializeField] private Image fuelImage;
    [SerializeField] private GameObject[] playerLifes;
    public TMP_Text name;
    private Timer timer;
    private GameOver end;
    public string nameValue;


    [Header("Coins")] 
    [SerializeField] private TextMeshProUGUI coinTMP;
    
    private float _currentJetpackFuel;
    private float _jetpackFuel;

    private void Start()
    {
        var savedName = PlayerPrefs.GetString("playerName");
        nameValue = savedName ?? "Player One";

        name.text = "Name:" + nameValue;
    }
    
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

    private GameObject FindInactiveObj(string objectStr){
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject currentObject in objects){
            if (currentObject.name == objectStr && !currentObject.activeInHierarchy){
                return currentObject;
            }
        }
        return null;
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

        if(currentLifes == 0){
            timer = GameObject.Find("Canvas").GetComponent<Timer>();
            timer.Finish();
            GameObject inactiveObj = FindInactiveObj("GameOverMenu");
            inactiveObj.SetActive(true);
            end = GameObject.Find("GameOverMenu").GetComponent<GameOver>();
            end.EndGameLogic();
        }
    }

    public void SaveUsername(string newName)
    {
        nameValue = newName;
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
