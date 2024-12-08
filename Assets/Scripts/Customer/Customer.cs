using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] Transform orderBubble;
    [SerializeField] float tip = 10;
    public Table table;
    [SerializeField] public bool inTableRange = false;
    [SerializeField] bool isSeated = false;

    GameObject upsetHead;
    GameObject angryHead;
    GameObject happyhead;
    GameObject body;
    GameObject waveBody;
    GameObject eatBody;
    GameObject eatHead;
   
    SpriteRenderer bodySR;
    // Start is called before the first frame update
    void Start()
    {
        orderBubble.GetComponent<SpriteRenderer>().color = Color.clear;

        happyhead = transform.Find("HappyHead")?.gameObject;
        upsetHead = transform.Find("UpsetHead")?.gameObject;
        angryHead = transform.Find("AngryHead")?.gameObject;

        body = transform.Find("Body")?.gameObject;
        waveBody = transform.Find("WaveBody")?.gameObject;
        eatBody = transform.Find("EatBody")?.gameObject;
        
        eatHead = transform.Find("EatHead")?.gameObject;
        
        if(happyhead == null) Debug.Log("Happy Head not found!");
        if(upsetHead == null) Debug.Log("Upset Head not found!");
        if(angryHead == null) Debug.Log("Angry Head not found!");

        if(body == null) Debug.Log("Body not found!");
        if(waveBody == null) Debug.Log("Wave body not found!");
        if(eatBody == null) Debug.Log("Eat body not found!");

        if(eatHead == null) Debug.Log("Eat head not found!");

    }

    // Update is called once per frame
    void Update()
    {
        if(!isSeated){
            float minDistance = float.MaxValue;
            Table closestTable = null;
            foreach(Table table in TableManager.singleton.tables){
                float distance = Vector3.Distance(table.transform.position, transform.position);
                if(distance < 2f && !table.IsOccupied()){
                    if(distance < minDistance){
                        minDistance = distance;
                        closestTable = table;
                        inTableRange = true;
                        break;
                    }
                    
                }
            }

            table = closestTable;
        }
        
    }

    public void Move(Vector3 movement){
        transform.position += movement * speed * Time.deltaTime;
    }

    public void MoveToward(Vector3 goalPos){
        goalPos.z = 0;
        goalPos += new Vector3(-.5f, 0, 0);
        Vector3 direction = goalPos - transform.position;
        if(Vector3.Distance(transform.position, goalPos) < 0.1f){
            return;
        }
        Move(direction.normalized);
    }

    public void Seat(Table table){
        isSeated = true;
        this.table = table;
    }

    public void Glow(){
        Debug.Log("Customer is glowing");
    }

    public void Wave(){
        //bodySR.color = Color.magenta;
        body.SetActive(false);
        waveBody.SetActive(true);
    }

    public void ResetBody(){
        body.SetActive(true);
        waveBody.SetActive(false);
        eatBody.SetActive(false);

        eatBody.SetActive(false);

        eatHead.SetActive(false);

    }

    public void Eat(){
        //bodySR.color = Color.green;
        body.SetActive(false);
        eatBody.SetActive(true);
        eatHead.SetActive(true);
    }
    
    public void SetOrder(Recipe order){
        Vector3 position = orderBubble.transform.position + new Vector3(0, 0.068f, 0);
        orderBubble.GetComponent<SpriteRenderer>().color = Color.white;
        GameObject orderIcon = Instantiate(order.GameObject(), position, Quaternion.identity);
        orderIcon.transform.localScale = Vector3.one * 0.13f;
        orderIcon.GetComponent<SpriteRenderer>().sortingOrder = 2;
        orderIcon.transform.SetParent(orderBubble);
    }

    public void RemoveOrder(){
        if(orderBubble != null) Destroy(orderBubble.GameObject());
    }

    public void Pay(Table table, Recipe order){
        float price = order.price + tip;
        Debug.Log("Customer price: " + price);
        table.PlaceMoney(price);
    }

    public void DecrementTip(){
        tip -= 2;
    }

    public void SetMoodHead(CustomerAI.MoodState mood){
        if(mood == CustomerAI.MoodState.HAPPY){
            upsetHead.SetActive(false);
            angryHead.SetActive(false);
            happyhead.SetActive(true);
        }
        if(mood == CustomerAI.MoodState.UPSET){
            upsetHead.SetActive(true);
            happyhead.SetActive(false);
        }
        if(mood == CustomerAI.MoodState.ANGRY){
            upsetHead.SetActive(false);
            angryHead.SetActive(true);
        }
    }

    
}
