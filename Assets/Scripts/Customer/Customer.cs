using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] Transform orderBubble;
    [SerializeField] float tip = 10;
    public Table table;
    public bool inTableRange = false;
   
    // Start is called before the first frame update
    void Start()
    {
        orderBubble.GetComponent<SpriteRenderer>().color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Table")){
            table = other.GetComponent<Table>();
            inTableRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Table")){
            table = null;
            inTableRange = false;
        }
    }

    public void Glow(){
        Debug.Log("Customer is glowing");
    }

    public void Wave(){
        GetComponent<SpriteRenderer>().color = Color.magenta;
    }

    public void Eat(){
        GetComponent<SpriteRenderer>().color = Color.green;
    }
    
    public void SetOrder(Recipe order){
        Vector3 position = orderBubble.transform.position + new Vector3(0, 0.068f, 0);
        orderBubble.GetComponent<SpriteRenderer>().color = Color.white;
        GameObject orderIcon = Instantiate(order.GameObject(), position, Quaternion.identity);
        orderIcon.transform.localScale = Vector3.one * 0.7f;
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

    
}
