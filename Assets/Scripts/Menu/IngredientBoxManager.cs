using System.Collections.Generic;
using UnityEngine;

public class IngredientBoxManager : MonoBehaviour
{
    public static IngredientBoxManager singleton;
    [SerializeField] List<IngredientBox> allIngredientBoxes;

    void Start()
    {
        if(singleton == null) singleton = this;
    }


}