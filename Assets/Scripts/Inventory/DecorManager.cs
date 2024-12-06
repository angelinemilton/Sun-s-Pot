using System.Collections.Generic;
using UnityEngine;

public class DecorManager : MonoBehaviour
{
    [SerializeField] List<DecorItem> decorItems;
    static int palmTree;
    void Awake()
    {
        palmTree = PlayerPrefs.GetInt("PalmTree", 0);
        SetOwnedVisible();
    }

    public static bool hasPalmTree(){
        return palmTree == 1 ? true : false;
    }

    void SetOwnedVisible(){
        foreach(DecorItem item in decorItems){
            if(item.decorName == "PalmTree" && hasPalmTree()){ 
                item.SetVisible();
                Debug.Log("Set Palm Tree visible");
            }
            if(item.decorName == "Garland" && GameStats.IsUnlockedGarlands()){
                item.SetVisible();
                Debug.Log("Set Garlands visible");
            }
        }
    }

}