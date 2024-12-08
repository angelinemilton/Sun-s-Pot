using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : MonoBehaviour
{
    [SerializeField] Ingredient ingredient;

    void Start()
    {
        Debug.Log("Has " + ingredient.ingredientName + ": " + GameStats.IsUnlockedIngredient(ingredient));
        if(!GameStats.IsUnlockedIngredient(ingredient)){
            
            gameObject.SetActive(false);
        }
        else{
            gameObject.SetActive(true);
        }
    }

    public Ingredient GetIngredient(){
        return ingredient;
    }

    
}
