using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    public Toggle Toggle;
    PlayerController PC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggler()
    {
        if(Toggle.isOn == false)
        {
            PC.Headbob = false;
            Debug.Log("Test");
        }
        else if(Toggle.isOn == true)
        {
            PC.Headbob = true;
            Debug.Log("Testt");
        }
    }
}
