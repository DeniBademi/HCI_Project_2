using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetName : MonoBehaviour
{
    private string input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInput(string name)
    {
        input = name;
        UIManager.Instance.nameValue = name;
        PlayerPrefs.SetString("playerName", name);
    }
}
