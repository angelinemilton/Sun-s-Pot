using UnityEngine;

public class GameStats
{
    //base stats
    readonly static string day = "Day";
    readonly static string bankAmount = "BankAmount";
    readonly static string todaysRevenue = "TodaysRevenue";
    readonly static string operationCost = "OperationCost";
    readonly static string profit = "Profit";
    
    //upgrades
    readonly static string palmTree = "PalmTree";
    readonly static string garlands = "Garlands";
    readonly static string deluxeChairs = "DeluxeChairs";
    readonly static string ingredients = "Ingredients";
    readonly static string recipes = "Recipes";

    readonly static string playerMoodFactor = "PlayerMoodFactor";

    public static void ResetAllData(){
        PlayerPrefs.SetInt(day, 0);
        PlayerPrefs.SetFloat(bankAmount, 0);
        PlayerPrefs.SetFloat(todaysRevenue, 0);
        PlayerPrefs.SetFloat(operationCost, 0);
        PlayerPrefs.SetFloat(profit, 0);
       
        //upgrades
        PlayerPrefs.SetInt(palmTree, 0);
        PlayerPrefs.SetInt(garlands, 0);
        PlayerPrefs.SetInt(deluxeChairs, 0);
        PlayerPrefs.SetString(ingredients, ""); //sting to hold names of all ingredients
        PlayerPrefs.SetString(recipes, "");

        PlayerPrefs.SetInt(playerMoodFactor, 0);
        
        Debug.Log("Bank Amount: " + PlayerPrefs.GetFloat("BankAmount"));
        Debug.Log("Palm Tree: " + PlayerPrefs.GetFloat("PalmTree"));

    }

    static void IncreasePlayerMoodFactor(){
        int newFactor =  PlayerPrefs.GetInt(playerMoodFactor) + 3;
        PlayerPrefs.SetInt(playerMoodFactor, newFactor);
    }

    public static int GetPlayerMoodFactor(){
        return PlayerPrefs.GetInt(playerMoodFactor);
    }

    public static bool IsUnlockedPalmTree(){
        return PlayerPrefs.GetInt(palmTree) == 1;
    }

    public static void UnlockPalmTree(){
        PlayerPrefs.SetInt(palmTree, 1);
        IncreasePlayerMoodFactor();
    }
    
    public static bool IsUnlockedGarlands(){
        return PlayerPrefs.GetInt(garlands) == 1;
    }

    public static void UnlockGarlands(){
        PlayerPrefs.SetInt(garlands, 1);
        IncreasePlayerMoodFactor();
    }

    public static bool IsUnlockedDeluxeChairs(){
        return PlayerPrefs.GetInt(deluxeChairs) == 1;
    }

    public static void UnlockDeluxeChairs(){
        PlayerPrefs.SetInt(deluxeChairs, 1);
        IncreasePlayerMoodFactor();
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

    public static void DecreaseBankAmount(float amount){
        float newAmount = PlayerPrefs.GetFloat(bankAmount) - amount;
        PlayerPrefs.SetFloat(bankAmount, newAmount);
    }

    public static int GetDay(){
        return PlayerPrefs.GetInt(day);
    }

    public static void IncreaseDay(){
        int newDayCount = PlayerPrefs.GetInt(day) + 1;
        PlayerPrefs.SetInt(day, newDayCount);
    }

    public static void SetProfit(float amount){
        PlayerPrefs.SetFloat(profit, amount);
    }

    public static float GetProfit(){
        return PlayerPrefs.GetFloat(profit);
    }

    public static void IncreaseOperationCost(float amount){
        float newCost = PlayerPrefs.GetFloat(operationCost) + amount;
        PlayerPrefs.SetFloat(operationCost, newCost);
    }

     public static void DecreaseOperationCost(float amount){
        float newCost = PlayerPrefs.GetFloat(operationCost) - amount;
        PlayerPrefs.SetFloat(operationCost, newCost);
    }

    public static float GetOperationCost(){
        return PlayerPrefs.GetFloat(operationCost);
    }

    public static void AddIngredient(Ingredient ingredient){
        string newIngredientsList = PlayerPrefs.GetString(ingredients) + ingredient.ingredientName + "-";
        PlayerPrefs.SetString(ingredients, newIngredientsList);
        IncreaseOperationCost(ingredient.price);
    }

    public static void RemoveIngredient(Ingredient ingredient){
        string newIngredientsList = PlayerPrefs.GetString(ingredients).Replace(ingredient.ingredientName + "-", "");
        PlayerPrefs.SetString(ingredients, newIngredientsList);
        DecreaseOperationCost(ingredient.price);
    }

    public static bool IsUnlockedIngredient(Ingredient ingredient){
        return PlayerPrefs.GetString(ingredients).Contains(ingredient.ingredientName);
    }

    public static void AddRecipe(Recipe recipe){
        string newRecipes = PlayerPrefs.GetString(recipes) + recipe.recipeName + "-";
        PlayerPrefs.SetString(recipes, newRecipes);
    }

    public static void RemoveRecipe(Recipe recipe){
        string newRecipesList = PlayerPrefs.GetString(recipes).Replace(recipe.recipeName + "-", "");
        PlayerPrefs.SetString(ingredients, newRecipesList);
    }

    public static bool IsUnlockedRecipe(Recipe recipe){
        return PlayerPrefs.GetString(recipes).Contains(recipe.recipeName);
    }
    
}