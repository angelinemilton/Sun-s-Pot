using UnityEngine;

public class DecorItem : MonoBehaviour
{
    bool visible = false;
    [SerializeField] public string decorName;
    void Start()
    {
        if(!visible) gameObject.SetActive(false);
        else gameObject.SetActive(true);
    }
    public void SetVisible(){
       visible = true;
    }

}