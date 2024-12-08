using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public static string PalmTree = "PalmTree";

    public void Exit(){
        Application.Quit();
    }

    public void Play(){
        SceneManager.LoadScene("RestaurantScene");
    }

    public void NewGame(){
        GameStats.ResetAllData();

        SceneManager.LoadScene("RestaurantScene");

    }
}
