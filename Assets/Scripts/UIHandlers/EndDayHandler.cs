using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDayHandler : MonoBehaviour
{

    public void Upgrades(){
        SceneManager.LoadScene("Upgrades");
    }

    public void StartNewDay(){
        SceneManager.LoadScene("RestaurantScene");
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
