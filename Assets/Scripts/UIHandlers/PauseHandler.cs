using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;

    void Awake()
    {
        pauseMenu.enabled = false;
    }

    public void OpenPauseMenu(){
        pauseMenu.enabled = true;
        Time.timeScale = 0;
    }

    public void ClosePauseMenu(){
        pauseMenu.enabled = false;
        Time.timeScale = 1;
    }

    public void Restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene("RestaurantScene");
    }

    public void MainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
