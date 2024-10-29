using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager singleton;
    [SerializeField] public Money money;

    void Start()
    {
        if(singleton == null) singleton = this;
    }
}