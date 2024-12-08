using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectRecipe : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recipeName;
    [SerializeField] SpriteRenderer recipeImage;
    [SerializeField] SpriteRenderer ingredient1;
    [SerializeField] SpriteRenderer ingredient2;
    [SerializeField] Button addButton;

    public void UploadRecipeData(Recipe recipe){
        recipeName.text = recipe.recipeName;
        recipeImage.sprite = recipe.gameObject.GetComponent<SpriteRenderer>().sprite;
        ingredient1.sprite = recipe.ingredientsList[0].gameObject.GetComponent<SpriteRenderer>().sprite;
        ingredient2.sprite = recipe.ingredientsList[1].gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}