using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TogglesGroup : MonoBehaviour
{
    // Start is called before the first frame update
    ToggleGroup currentToggleGroup;
    GameObject level;

    public Toggle CheckToggleOn (){
        foreach (Toggle t in currentToggleGroup.ActiveToggles()) {
            if (t.isOn == true) {
                return t;
            }
        }
        return null;
    }

    // public Toggle currentSelection{
    //     get 
    //     { 
    //         return currentToggleGroup.ActiveToggles().FirstOrDefault();
    //     }
    // }

    void Start()
    {
        currentToggleGroup = GetComponent<ToggleGroup> ();
        Toggle currentToggle = CheckToggleOn();
        if (currentToggle == GameObject.Find("EasyDifficulty")){
            level = GameObject.FindGameObjectWithTag("Level01");
            
        }
        else if(currentToggle == GameObject.Find("EasyDifficulty")){
            level = GameObject.FindGameObjectWithTag("Level02");
        }
        else{
            level = GameObject.FindGameObjectWithTag("Level03");
        }
        level.SetActive(true);
    }

    public void SelectToggle(int id){
        var toggles = currentToggleGroup.GetComponentsInChildren<Toggle> ();
        toggles [id].isOn = true;
    }
}

