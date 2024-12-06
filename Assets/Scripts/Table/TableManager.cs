using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public static TableManager singleton;
    [SerializeField] public List<Table> tables;

    void Start()
    {
        if(singleton == null) singleton = this;
    }

    public bool AllTablesCleared(){
        foreach(Table table in tables){
            if(table.hasMoney) return false;
        }
        
        return true;
    }
}