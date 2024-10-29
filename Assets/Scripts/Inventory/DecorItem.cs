using UnityEngine;

public class DecorItem : MonoBehaviour
{
    bool visible = false;
    [SerializeField] public string decorName;
    void Start()
    {
        if(!visible) GetComponent<SpriteRenderer>().color = Color.clear;
        else GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void SetVisible(){
       visible = true;
    }

}