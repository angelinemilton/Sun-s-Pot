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
    [SerializeField] Recipe currRecipe;

    void Start()
    {
        addButton.gameObject.SetActive(false);
        recipeName.text = "Select a recipe to add to the Menu!";
    }
    

    public void UploadRecipeData(Recipe recipe){
        addButton.gameObject.SetActive(true);
        currRecipe = recipe;
        recipeName.text = recipe.recipeName;
        recipeImage.sprite = recipe.gameObject.GetComponent<SpriteRenderer>().sprite;
        ingredient1.sprite = recipe.ingredientsList[0].gameObject.GetComponent<SpriteRenderer>().sprite;
        ingredient2.sprite = recipe.ingredientsList[1].gameObject.GetComponent<SpriteRenderer>().sprite;

        TextMeshProUGUI buttonText = addButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
       
        if(!GameStats.IsUnlockedIngredient(currRecipe.ingredientsList[0]) || !GameStats.IsUnlockedIngredient(currRecipe.ingredientsList[1])){
            //buy ingredients display
            buttonText.text = "Buy Ingredients";
            //disable button
            addButton.interactable = false;
        }
        else{
            if(!GameStats.IsUnlockedRecipe(currRecipe)){
                //add to menu display
                addButton.interactable = true;
                buttonText.text = "Add to Menu";
            }
            else{
                addButton.interactable = false;
                buttonText.text = "Owned!";
            }
        }
    }

    public void AddButtonOnClick(){
        Debug.Log("Added " + currRecipe.name + " to menu");
        GameStats.AddRecipe(currRecipe);
        Debug.Log("Recipes: " + PlayerPrefs.GetString("Recipes"));
        
        addButton.interactable = false;
        addButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Owned!";
    }
}