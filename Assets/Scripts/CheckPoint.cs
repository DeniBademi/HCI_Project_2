using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static Action<int> OnLevelCompleted;
    private Timer timer;
    
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
            }
            OnLevelCompleted?.Invoke(levelIndex);
            Debug.Log(levelIndex.ToString());
        }
    }
}
