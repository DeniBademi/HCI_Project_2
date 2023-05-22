using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text textTimer;
    private float startTime;
    private bool isRunning = false;
    private BoxCollider2D checkpointCollider;

    private static Timer instance;

    public static Timer Instance
    {
        get { return instance; }
    }

    private void Awake(){

         if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    void Start()
    {
        StartTimer();
        GameObject checkpointObj = GameObject.Find("Checkpoint");
        if (checkpointObj != null){
            checkpointCollider = checkpointObj.GetComponent<BoxCollider2D>();
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            float elapsedTime = Time.time - startTime;
            string minutes = ((int)elapsedTime / 60).ToString();
            string seconds = (elapsedTime % 60).ToString("f2");
            textTimer.text = minutes + ":" + seconds;
        }

        if (checkpointCollider != null & !isRunning)
        {
            return;
        }
    }

    public void Finish(){
        StopTimer();
        textTimer.color = Color.red;
    }
}
