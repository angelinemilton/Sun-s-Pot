using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndDayStatsHandler : MonoBehaviour
{
    public static float bankAmount;
    public static float todaysRevenue;
    public static float operationCost;
    public static float profit;

    [SerializeField] TextMeshProUGUI bankText;
    [SerializeField] TextMeshProUGUI revenueText;
    [SerializeField] TextMeshProUGUI profitText;
    [SerializeField] TextMeshProUGUI operationCostText;
    [SerializeField] TextMeshProUGUI dayText;

    void Start()
    {
        dayText.text = "Day " + GameStats.GetDay() + "!";

        todaysRevenue = GameStats.GetTodaysRevenue();
        operationCost = GameStats.GetOperationCost();
        profit = todaysRevenue - operationCost;
        GameStats.AddToBankAmount(profit);
        bankAmount = GameStats.GetBankAmount();
        SetMoneyText();
        
    }

    void SetMoneyText(){
        
        revenueText.SetText("+$" + todaysRevenue);
        operationCostText.SetText("-$" + operationCost);

        if(profit < 0) profitText.SetText("-$" + Mathf.Abs(profit));
        else profitText.SetText("+$" + profit);
        
        if(bankAmount < 0) bankText.text = "-$" + Mathf.Abs(bankAmount);
        else bankText.SetText("$" + bankAmount);

    }
}
