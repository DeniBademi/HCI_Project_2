using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text textTimer;
    private float startTime;
    //private bool finnished = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Checkpoint").GetComponent<BoxCollider2D>().isTrigger == true){
            Finnish();
            return;
        }
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        textTimer.text = minutes + ":" + seconds;
    }

    public void Finnish(){
        //finnished = true;
        textTimer.color = Color.red;
    }
}
