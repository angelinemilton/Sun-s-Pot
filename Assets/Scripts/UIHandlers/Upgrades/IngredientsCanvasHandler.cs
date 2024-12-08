using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientsCanvasHandler : MonoBehaviour
{
    
    [SerializeField] Ingredient sunFish;
    [SerializeField] Ingredient rice;
    [SerializeField] Ingredient sunDrops;
    [SerializeField] Ingredient coconut;

    [Header("Buttons")]
    [SerializeField] Button buySunFish;
    [SerializeField] Button buyRice;
    [SerializeField] Button buySunDrops;
    [SerializeField] Button buyCoconut;

    void Start()
    {
        if(GameStats.IsUnlockedIngredient(sunFish)) SetButtonOwned(buySunFish);
        if(GameStats.IsUnlockedIngredient(rice)) SetButtonOwned(buyRice);
        if(GameStats.IsUnlockedIngredient(sunDrops)) SetButtonOwned(buySunDrops);
        if(GameStats.IsUnlockedIngredient(coconut)) SetButtonOwned(buyCoconut);
    }

    void Update()
    {
        if(GameStats.GetBankAmount() < sunFish.price) buySunFish.interactable = false;
        if(GameStats.GetBankAmount() < rice.price) buyRice.interactable = false;
        if(GameStats.GetBankAmount() < sunDrops.price) buySunDrops.interactable = false;
        if(GameStats.GetBankAmount() < coconut.price) buyCoconut.interactable = false;
    }

    public void BuySunFish(){
        Debug.Log("Bought Sun Fish");
        SetButtonOwned(buySunFish);
        GameStats.AddIngredient(sunFish);
    }

    public void BuyRice(){
        Debug.Log("Bought Rice");
        SetButtonOwned(buyRice);
        GameStats.AddIngredient(rice);
    }

    public void BuySunDrops(){
        Debug.Log("Bought Sun Drops");
        SetButtonOwned(buySunDrops);
        GameStats.AddIngredient(sunDrops);
    }

    public void BuyCoconut(){
        Debug.Log("Bought coconut");
        SetButtonOwned(buyCoconut);
        GameStats.AddIngredient(coconut);
    }

    void SetButtonOwned(Button button){
        button.interactable = false;
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Owned!";
        Destroy(button.transform.GetChild(1).gameObject); //destroy money icon
    }
}
