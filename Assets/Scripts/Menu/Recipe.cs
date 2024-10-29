using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    [SerializeField] public string recipeName;
    [SerializeField] List<Ingredient> ingredientsList;
    [SerializeField] public float price = 15;
    IngredientList ingredients;

    void Awake()
    {
        ingredients = new IngredientList(new HashSet<Ingredient>(ingredientsList));
        
    }

    public void Unlock(){
        MenuManager.singleton.AddToMenu(this);
    }

    public string GetName(){
        return recipeName;
    }

    public IngredientList GetIngredients(){
        return ingredients;
    }
}