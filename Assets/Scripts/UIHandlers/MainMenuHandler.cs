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
        PlayerPrefs.SetFloat("BankAmount", 0);
        PlayerPrefs.SetFloat("Day", 1);
        
        //upgrades
        PlayerPrefs.SetInt("PalmTree", 0);
        PlayerPrefs.SetInt("Garlands", 0);
        
        Debug.Log("Bank Amount: " + PlayerPrefs.GetFloat("BankAmount"));
        Debug.Log("Palm Tree: " + PlayerPrefs.GetFloat("PalmTree"));

        SceneManager.LoadScene("RestaurantScene");

    }
}
