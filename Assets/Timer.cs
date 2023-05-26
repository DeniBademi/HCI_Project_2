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

    public void ResetTimer()
    {
        textTimer.color = Color.white;
        StartTimer();
    }

    void Start()
    {
        //The time starts counting even in the StartingMenu because the
        // canvas is active and the function start() is being executed
        // even though we are not in the game yet. 
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

    public float timeTaken(){
        return Time.time - startTime;
    }

    public void Finish(){
        StopTimer();
        textTimer.color = Color.red;
    }
}
