using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDayHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
