using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndDayStatsHandler : MonoBehaviour
{
    public static float bankAmount;
    public static float todaysRevenue;

    [SerializeField] TextMeshProUGUI bankText;
    [SerializeField] TextMeshProUGUI revenueText;

    void Start()
    {
        bankAmount = GameStats.GetBankAmount();
        todaysRevenue = GameStats.GetTodaysRevenue();
        SetMoneyText();
        
    }

    void SetMoneyText(){
        bankText.SetText("$" + bankAmount);
        revenueText.SetText("$" + todaysRevenue);
    }
}
