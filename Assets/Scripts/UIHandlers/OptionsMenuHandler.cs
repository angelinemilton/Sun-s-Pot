using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuHandler : MonoBehaviour
{

    void Awake()
    {
        CloseMenu();
    }

    public void OpenMenu(){
        GetComponent<Canvas>().enabled = true;
    }

    public void CloseMenu(){
        GetComponent<Canvas>().enabled = false;
    }


}
