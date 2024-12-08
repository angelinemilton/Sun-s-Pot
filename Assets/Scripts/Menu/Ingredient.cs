using Unity.VisualScripting;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] public Color fillingColor;
    [SerializeField] Sprite icon;
    [SerializeField] public string ingredientName;
    [SerializeField] public float price;

    public Sprite GetIcon(){
        return icon;
    }
    
    public override string ToString()
    {
        return ingredientName;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Ingredient other = (Ingredient)obj;
        return ingredientName == other.ingredientName;
    }

    public override int GetHashCode()
    {
        return ingredientName != null ? ingredientName.GetHashCode() : 0;
    }

}