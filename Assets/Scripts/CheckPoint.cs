using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static Action<int> OnLevelCompleted;
    private Timer timer;
    public GameOver end;//!
    
    [Header("Settings")] 
    [SerializeField] private int levelIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(levelIndex == 2){
                Debug.Log("Hello World");
                timer = GameObject.Find("Canvas").GetComponent<Timer>();
                timer.Finish();
                GameObject inactiveObj = FindInactiveObj("GameOverMenu");
                inactiveObj.SetActive(true);
                end = GameObject.Find("GameOverMenu").GetComponent<GameOver>();
                end.EndGameLogic();//!
            }
            OnLevelCompleted?.Invoke(levelIndex);
            Debug.Log(levelIndex.ToString());
        }
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
}
