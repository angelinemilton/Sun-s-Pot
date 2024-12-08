using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [Header("Filling")]
    [SerializeField] GameObject filling;
    [SerializeField] Color fillColor = Color.magenta;
    SpriteRenderer fillRender;

    [Header("Ingredients")]
    [SerializeField] IngredientList ingredients;
    [SerializeField] List<Ingredient> ingredientsList;

    [Header("Slots")]
    [SerializeField] List<GameObject> slots;
    int slotIndex = 0;

    Recipe recipe;

    void Awake()
    {
        ingredients = new IngredientList(new HashSet<Ingredient>());
        foreach(GameObject slot in slots){
            slot.GetComponent<SpriteRenderer>().color = Color.clear;
        }

        fillColor = new Color();
        fillRender = filling.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
        RemoveFilling();
    }

    void AddFilling(Color newColor){
        fillColor = newColor; //replace with the recipe color
        fillColor.a = 225;
        fillRender.color = fillColor;
    }

    public void RemoveFilling(){
        fillRender.color = Color.clear;
    }

    public void AddIngredient(Ingredient ingredient){   
        if(ingredient == null){
            Debug.Log("Ingredient is null");
            return;
        }
        bool canAdd = ingredients.Add(ingredient);
        Debug.Log("Can add ingredient: " + canAdd);

        recipe = GetRecipe();
        
        if(recipe != null){
            Debug.Log("Found recipe: " + recipe.name);
        }
        else{
            Debug.Log("Can't find recipe");
        }

        if(canAdd && slotIndex < slots.Count){
            Debug.Log("Put in ingredient");
            AddFilling(ingredient.GetComponent<Ingredient>().fillingColor);
            ingredientsList.Add(ingredient);
            slots[slotIndex].GetComponent<SpriteRenderer>().sprite = ingredient.GetIcon();
            slots[slotIndex].GetComponent<SpriteRenderer>().color = Color.white;
            slotIndex++;
        }
    }

    Recipe GetRecipe(){
        //menu manager check if valid recipe
        return MenuManager.singleton.GetRecipe(ingredients);
    }

    public Recipe TakeRecipe(){
        if(recipe != null){
            RemoveIngredients();
            slotIndex = 0;
            Recipe temp = recipe;
            recipe = null;
            return temp;
        }
        return null;
    }

    public void RemoveIngredients(){
        ingredients = new IngredientList(new HashSet<Ingredient>());
        ingredientsList = new List<Ingredient>();
        foreach(GameObject slot in slots){
            slot.GetComponent<SpriteRenderer>().color = Color.clear;
        }
        slotIndex = 0;
        RemoveFilling();
    }

    

    
}