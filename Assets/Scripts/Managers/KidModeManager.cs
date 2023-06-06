using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   

public class KidModeManager : MonoBehaviour
{
    public static bool KidModeEnabled = false;
    public LevelManager levelManager;

    public void ToggleKidMode(bool enabled)
    {
        levelManager.ToggleKidMode(enabled);
    }

}
