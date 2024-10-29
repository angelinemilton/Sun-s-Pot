using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestuarantManager : MonoBehaviour
{
    public static RestuarantManager singleton;
    [SerializeField] float openingTime = 0;
    [SerializeField] float closingTime = 180;
    [SerializeField] float currentTime;

    [SerializeField] float timeSpeed = 2f;

    [SerializeField] bool closed = false;

    [SerializeField] TextMeshProUGUI revenueText;
    static float revenue = 0;

    // Start is called before the first frame update
    void Start()
    {
        revenue = 0;
        revenueText.SetText("Revenue: $" + revenue);
        if(singleton == null){
            singleton = this;
        }
        currentTime = openingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += timeSpeed * Time.deltaTime;
        if(currentTime >= closingTime){
            CloseRestuarant();
        }

        if(closed && !CustomerGenerator.singleton.customersRemaining && TableManager.singleton.AllTablesCleared()){
            Debug.Log("Changing Scene");
            PlayerPrefs.SetFloat("TodaysRevenue", revenue);
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
        revenueText.SetText("Revenue: $" + revenue);
    }
}
