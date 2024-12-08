using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Table : MonoBehaviour
{ 
    [SerializeField] GameObject rightSeat;
    [SerializeField] GameObject rightFoodSlot;
    [SerializeField] GameObject moneySlot;
    [SerializeField] Sprite deluxeChair;
    [SerializeField] bool occupied = false;

    public bool orderPlaced = false;
    public bool hasMoney = false;

    Customer customer;
    Recipe order;
    Recipe placedOrder;
    Money money;

    void Start()
    {
        if(GameStats.IsUnlockedDeluxeChairs()) rightSeat.GetComponent<SpriteRenderer>().sprite = deluxeChair;
        rightFoodSlot.GetComponent<SpriteRenderer>().color = Color.clear;
        moneySlot.GetComponent<SpriteRenderer>().color = Color.clear;
    }

    public void Glow(){
        GetComponent<SpriteRenderer>();
        Debug.Log("table is glowing");
    }


    public Vector3 GetSeatPosition(){
       //returns seat position but a little up so the customer is sitting above it
        return rightSeat.transform.position + new Vector3(0,.5f,0);
        
    }

    public void SeatCustomer(Customer customerToSeat){
        if(!occupied){
            customer = customerToSeat;
            occupied = true;
            customerToSeat.transform.position = rightSeat.transform.position + new Vector3(0,.5f,0);
            customerToSeat.transform.SetParent(this.transform);
        }
        
    }

    public bool IsOccupied(){
        return occupied;
    }

    public void ClearTable(){
        occupied = false;
        
        Destroy(money.GameObject());
        hasMoney = false;
        RestuarantManager.singleton.AddToRevenue(money.GetAmount());
    }

    public void SetOrder(Recipe recipe){
        order = recipe;
        Debug.Log("Table order is set to: " + order.name);

    }

    public bool ServeOrder(Recipe recipe){
        if(order == null) return false;
        if(recipe == null){
            Debug.Log("Place order failed, recipe null");
            return false;
        } 
        else if(recipe.recipeName == order.recipeName){
            placedOrder = Instantiate(recipe, rightFoodSlot.transform.position, Quaternion.identity);
            placedOrder.transform.localScale = Vector3.one * 0.2f;
            placedOrder.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            orderPlaced = true;
            if(customer != null){
                customer.RemoveOrder();
            }
            else Debug.Log("Customer is null");
            
            return true;
        }
        
        Debug.Log("Wrong recipe given. Expected: " + order.recipeName + " Got: " + recipe.recipeName);
        return false;
    
    }

    public void PlaceMoney(float price){
        if(placedOrder != null) ClearFood();
        order = null;
        money = Instantiate(MoneyManager.singleton.money, moneySlot.transform.position, Quaternion.identity);
        money.SetAmount(price);
      
        Debug.Log("The price of money placed: " + money.GetAmount());
        hasMoney = true;
    }

    void ClearFood(){
        Destroy(placedOrder.GameObject());
    }

    public void SetUnoccupied(){
        occupied = false;
    }


}
