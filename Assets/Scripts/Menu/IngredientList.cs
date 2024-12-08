using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class IngredientList
{
    public HashSet<Ingredient> ingredients;

    public IngredientList(HashSet<Ingredient> ingredients){
        //Debug.Log(ingredients);
        this.ingredients = new HashSet<Ingredient>();
        foreach(Ingredient ingredient in ingredients){
            this.ingredients.Add(ingredient);
        }
       
    }

    public bool Add(Ingredient ingredient){
        foreach(Ingredient ingredient1 in ingredients){
            Debug.Log(ingredient1.ingredientName);
        }
        return ingredients.Add(ingredient);
    }

    public override bool Equals(object obj)
    {   
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        return ingredients.SetEquals(((IngredientList)obj).ingredients);
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        int hash = 0;
        foreach (var ingredient in ingredients)
        {
            hash ^= ingredient.GetHashCode();
        }

        return hash;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("IngredientList: [");

        foreach (var ingredient in ingredients)
        {
            sb.Append(ingredient.ToString());
            sb.Append(", ");
        }
        if (ingredients.Count > 0)
        {
            sb.Length -= 2;
        }

        sb.Append("]");
        return sb.ToString();
    }
}