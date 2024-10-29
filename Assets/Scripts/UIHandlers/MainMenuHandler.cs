using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit(){
        Application.Quit();
    }

    public void Play(){
        SceneManager.LoadScene("RestaurantScene");
    }

    public void NewGame(){
        PlayerPrefs.SetFloat("BankAmount", 0);
        PlayerPrefs.SetInt("PalmTree", 0);
        Debug.Log("Bank Amount: " + PlayerPrefs.GetFloat("BankAmount"));
        SceneManager.LoadScene("RestaurantScene");
    }
}
