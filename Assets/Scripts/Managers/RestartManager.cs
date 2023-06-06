 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class RestartManager : MonoBehaviour
 {
     [SerializeField] private GameObject levelManager;
     [SerializeField] private GameObject gameOverMenu;
    public void ButtonRestartClicked(){
         LevelManager lm = levelManager.GetComponent<LevelManager>();
        //  lm.RestartGame();
         gameOverMenu.SetActive(false);
     }
 }
