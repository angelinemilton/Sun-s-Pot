using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager singleton;
    [SerializeField] public List<Recipe> allRecipes;
    [SerializeField] public List<Recipe> unlockedRecipes;
    
    Dictionary<Recipe, IngredientList> recipeToIngredients;
    Dictionary<IngredientList, Recipe> ingredientsToRecipe;

    void Start()
    {
        recipeToIngredients = new Dictionary<Recipe, IngredientList>();
        ingredientsToRecipe = new Dictionary<IngredientList, Recipe>();
        if(singleton == null){
            singleton = this;
        }
        //TODO until we have unlocks in game
        foreach(Recipe recipe in unlockedRecipes){
            recipeToIngredients.Add(recipe, recipe.GetIngredients());
            ingredientsToRecipe.Add(recipe.GetIngredients(), recipe);
        }
    }

    public void AddToMenu(Recipe recipe){
        unlockedRecipes.Add(recipe);
       
    }

    public List<Recipe> GetAvailableMenuItems(){
        return unlockedRecipes;
    }

    public Recipe GetRecipe(IngredientList ingredients){
        return ingredientsToRecipe.ContainsKey(ingredients) ? ingredientsToRecipe[ingredients] : null;
    }

}