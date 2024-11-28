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
    // Start is called before the first frame update
    void Start()
    {
        bankAmount = PlayerPrefs.GetFloat("BankAmount", 0);
        todaysRevenue = PlayerPrefs.GetFloat("TodaysRevenue", 0);
        // bankAmount += todaysRevenue;
        // PlayerPrefs.SetFloat("BankAmount", bankAmount);
        SetMoneyText();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetMoneyText(){
        bankText.SetText("$" + bankAmount);
        revenueText.SetText("$" + todaysRevenue);
    }
}
