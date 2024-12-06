using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static float bankAmount;
    public static float todaysRevenue;

    [SerializeField] TextMeshProUGUI bankText;
    [SerializeField] TextMeshProUGUI revenueText;

    void Start()
    {
        bankAmount = PlayerPrefs.GetFloat("BankAmount", 0);
        todaysRevenue = PlayerPrefs.GetFloat("TodaysRevenue", 0);
        SetMoneyText();
        
    }

    void SetMoneyText(){
        bankText.SetText("$" + bankAmount);
        revenueText.SetText("$" + todaysRevenue);
    }
}
