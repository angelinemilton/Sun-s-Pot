using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMenuHandler : MonoBehaviour
{
    [Header("Recipes")]
    [SerializeField] Recipe flamedSunFish;
    [SerializeField] Recipe sunSetRefresher;
    [SerializeField] Recipe friedSunRays;
    [SerializeField] InspectRecipe inspectRecipe;

    public void FlamedSunFishClick(){
        Debug.Log("Clicked Flamed Sun Fish");
        inspectRecipe.UploadRecipeData(flamedSunFish);
    }

    public void SunSetRefresherClick(){
        Debug.Log("Clicked SunSet refresher button");
        inspectRecipe.UploadRecipeData(sunSetRefresher);
    }

    public void FriedSunRaysClick(){
        Debug.Log("Clicked fried sun rays");
        inspectRecipe.UploadRecipeData(friedSunRays);
    }
}
