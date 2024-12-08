using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    [SerializeField] public float entryOffset = 0;
    [SerializeField] GameObject startOfLine;
    [SerializeField] Transform spawnPoint;
    [SerializeField] List<Customer> customerPrefabs;

    [SerializeField] float spawnDelay = 10;

    [SerializeField] public AudioSource customerCall;
    [SerializeField] public bool customersRemaining = true;

    public Vector3 enterPos;

    public int customersCount = 0;
    public static CustomerGenerator singleton;

    

    void Start()
    {
        if(singleton == null){
            singleton = this;
        }
        enterPos = startOfLine.transform.position;
        //increasing spawn delay every day
        spawnDelay = spawnDelay - (GameStats.GetDay() * 2);
        if(spawnDelay < 3) spawnDelay = 3;
        GenerateCustomers();
    }

    void Update()
    {
        if(customersCount == 0) customersRemaining = false;
    }

    Customer SpawnCustomer(){
        int index = Random.Range(0, customerPrefabs.Count);
        Customer customerPrefab = customerPrefabs[index];
        return Instantiate(customerPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    void GenerateCustomers(){
        StartCoroutine(GenerateCustomerRoutine());
        IEnumerator GenerateCustomerRoutine(){
            Debug.Log("Restuarant closed: " + RestuarantManager.singleton.IsClosed());
            while(!RestuarantManager.singleton.IsClosed()){
                SpawnCustomer();
                customersCount++;
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

    public void TakeCustomerFromLine(){
        Debug.Log("Number of customers: " + customersCount);
    }
}
