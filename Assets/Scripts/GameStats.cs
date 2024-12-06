using UnityEngine;

public class GameStats
{
    readonly static string bankAmount = "BankAmount";
    readonly static string palmTree = "PalmTree";
    readonly static string garlands = "Garlands";
    readonly static string deluxeChairs = "DeluxeChairs";
    readonly static string todaysRevenue = "TodaysRevenue";
    readonly static string day = "Day";

    public static void ResetAllData(){
        PlayerPrefs.SetFloat(bankAmount, 0);
        PlayerPrefs.SetFloat(todaysRevenue, 0);
        PlayerPrefs.SetInt(day, 0);
        //upgrades
        PlayerPrefs.SetInt(palmTree, 0);
        PlayerPrefs.SetInt(garlands, 0);
        PlayerPrefs.SetInt(deluxeChairs, 0);
        
        Debug.Log("Bank Amount: " + PlayerPrefs.GetFloat("BankAmount"));
        Debug.Log("Palm Tree: " + PlayerPrefs.GetFloat("PalmTree"));

    }

    public static bool IsUnlockedPalmTree(){
        return PlayerPrefs.GetInt(palmTree) == 1;
    }

    public static void UnlockPalmTree(){
        PlayerPrefs.SetInt(palmTree, 1);
    }
    
    public static bool IsUnlockedGarlands(){
        return PlayerPrefs.GetInt(garlands) == 1;
    }

    public static void UnlockGarlands(){
        PlayerPrefs.SetInt(garlands, 1);
    }

    public static bool IsUnlockedDeluxeChairs(){
        return PlayerPrefs.GetInt(deluxeChairs) == 1;
    }

    public static void UnlockDeluxeChairs(){
        PlayerPrefs.SetInt(deluxeChairs, 1);
    }

    public static void SetTodaysRevenue(float newRevenue){
        PlayerPrefs.SetFloat(todaysRevenue, newRevenue);
    }

    public static float GetTodaysRevenue(){
        return PlayerPrefs.GetFloat(todaysRevenue, 0);
    }

    public static float GetBankAmount(){
        return PlayerPrefs.GetFloat(bankAmount);
    }

    public static void AddToBankAmount(float amount){
        float newAmount = PlayerPrefs.GetFloat(bankAmount) + amount;
        PlayerPrefs.SetFloat(bankAmount, newAmount);
    }

    public static int GetDay(){
        return PlayerPrefs.GetInt(day);
    }

    public static void IncreaseDay(){
        int newDayCount = PlayerPrefs.GetInt(day) + 1;
        PlayerPrefs.SetInt(day, newDayCount);
    }
    
}