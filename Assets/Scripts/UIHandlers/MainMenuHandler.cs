using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] Ingredient sunfish;
    [SerializeField] Ingredient rice;
    [SerializeField] Recipe flamedSunFish;

    public void Exit(){
        Application.Quit();
    }

    public void Play(){
        SceneManager.LoadScene("RestaurantScene");
    }

    public void NewGame(){
        GameStats.ResetAllData();
        GameStats.AddIngredient(sunfish);
        GameStats.AddIngredient(rice);
        GameStats.AddRecipe(flamedSunFish);
        Debug.Log("Recipes: " + PlayerPrefs.GetString("Recipes"));
        Debug.Log("Operational Cost: " + GameStats.GetOperationCost());
        Debug.Log("Ingredients list: " + PlayerPrefs.GetString("Ingredients"));
        SceneManager.LoadScene("RestaurantScene");

    }
}
