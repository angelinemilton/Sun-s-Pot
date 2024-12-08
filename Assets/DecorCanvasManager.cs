using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecorCanvasManager : MonoBehaviour
{
    [SerializeField] Button buyPalmButton;
    [SerializeField] Button buyGarlandButton;
    [SerializeField] Button buyDeluxeChairButton;

    float palmPrice = 60;
    float garlandPrice = 40;
    float deluxeChairPrice = 40;

    void Start()
    {
        if(GameStats.IsUnlockedPalmTree()) SetButtonOwned(buyPalmButton);
        if(GameStats.IsUnlockedGarlands()) SetButtonOwned(buyGarlandButton);
        if(GameStats.IsUnlockedDeluxeChairs()) SetButtonOwned(buyDeluxeChairButton);

    }

    void Update()
    {
        if(GameStats.GetBankAmount() < palmPrice) buyPalmButton.interactable = false;
        if(GameStats.GetBankAmount() < garlandPrice) buyGarlandButton.interactable = false;
        if(GameStats.GetBankAmount() < deluxeChairPrice) buyDeluxeChairButton.interactable = false;
    }

    void SetButtonOwned(Button button){
        button.interactable = false;
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Owned!";
        Destroy(button.transform.GetChild(1).gameObject); //destroy money icon
    }

    public void BuyPalm(){
        //upate decor stat
        GameStats.UnlockPalmTree();
        //update bank
        GameStats.DecreaseBankAmount(palmPrice);
        //set owned style
        SetButtonOwned(buyPalmButton);
    }

    public void BuyGarlands(){
        //upate decor stat
        GameStats.UnlockGarlands();
        //update bank
        GameStats.DecreaseBankAmount(garlandPrice);
        //set owned style
        SetButtonOwned(buyGarlandButton);
    }

    public void BuyDeluxeChair(){
         //upate decor stat
        GameStats.UnlockDeluxeChairs();
        //update bank
        GameStats.DecreaseBankAmount(deluxeChairPrice);
        //set owned style
        SetButtonOwned(buyPalmButton);
    }
}
