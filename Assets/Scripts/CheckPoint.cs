using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static Action<int> OnLevelCompleted;
    
    [Header("Settings")] 
    [SerializeField] private int levelIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnLevelCompleted?.Invoke(levelIndex);
            //Debug.Log(levelIndex.ToString());
            //denis
        }
    }
}
