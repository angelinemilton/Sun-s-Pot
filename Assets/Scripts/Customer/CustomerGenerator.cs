using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    [SerializeField] public float entryOffset = 0;
    [SerializeField] GameObject startOfLine;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Customer customer;

    [SerializeField] float spawnDelay = 10;

    [SerializeField] float lineOffset = 1;
    float endOfLineOffset = 0;

    public Vector3 enterPos;

    public int customersCount = 0;

    [SerializeField] public bool customersRemaining = true;


    public static CustomerGenerator singleton;
    // Start is called before the first frame update
    void Start()
    {
        if(singleton == null){
            singleton = this;
        }
        enterPos = startOfLine.transform.position;
        GenerateCustomers();
    }

    // Update is called once per frame
    void Update()
    {
        enterPos = startOfLine.transform.position - new Vector3(endOfLineOffset, 0, 0);
        if(customersCount == 0) customersRemaining = false;
    }

    Customer SpawnCustomer(){
        return Instantiate(customer, spawnPoint.transform.position, Quaternion.identity);
    }

    void GenerateCustomers(){
        StartCoroutine(GenerateCustomerRoutine());
        IEnumerator GenerateCustomerRoutine(){
            Debug.Log("Restuarant closed: " + RestuarantManager.singleton.IsClosed());
            while(!RestuarantManager.singleton.IsClosed()){
                SpawnCustomer();
                customersCount++;
                endOfLineOffset += lineOffset;
                
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

    public void TakeCustomerFromLine(){
        endOfLineOffset -= lineOffset;
        Debug.Log("Number of customers: " + customersCount);
    }
}
