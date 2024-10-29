using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] float amount;

    public void SetAmount(float newAmount){
        amount = newAmount;
    }

    public float GetAmount(){
        return amount;
    }
}