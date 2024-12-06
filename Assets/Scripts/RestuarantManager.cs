using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestuarantManager : MonoBehaviour
{
    public static RestuarantManager singleton;
    [SerializeField] float closingHour = 16;
    [SerializeField] float hour = 11;
    [SerializeField] float minute = 0;

    [SerializeField] float timeSpeed = 2f;

    [SerializeField] bool closed = false;

    [SerializeField] TextMeshProUGUI revenueText;
    [SerializeField] TextMeshProUGUI timeText;
    static float revenue = 0;

    // Start is called before the first frame update
    void Start()
    {
        revenue = 0;
        revenueText.SetText("$" + revenue);
        if(singleton == null){
            singleton = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetTimeText();

        if(closed && !CustomerGenerator.singleton.customersRemaining && TableManager.singleton.AllTablesCleared()){
            Debug.Log("Changing Scene");
            GameStats.IncreaseDay();
            GameStats.SetTodaysRevenue(revenue);
            GameStats.AddToBankAmount(revenue);
            SceneManager.LoadScene("EndDay");
        }
        
    }

    void CloseRestuarant(){
        closed = true;
        //put closed sign
    }

    public bool IsClosed(){
        return closed;
    }

    public void AddToRevenue(float amount){
        revenue += amount;
        revenueText.SetText("$" + revenue);
    }

    void SetTimeText(){
        minute += timeSpeed * Time.deltaTime;
        if(minute >= 59){
            hour++;
            minute = 0;
        }
        if(hour >= closingHour){
            CloseRestuarant();
        }
        float hourString = hour > 12 ? hour - 12 : hour;
        if(minute <= 9) timeText.text = hourString + ":0" + minute.ToString("F0");
        else timeText.text = hourString + ":" + minute.ToString("F0");
    }
}
