using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : MonoBehaviour
{
    [SerializeField] Ingredient ingredient;

    public Ingredient GetIngredient(){
        return ingredient;
    }

    
}
