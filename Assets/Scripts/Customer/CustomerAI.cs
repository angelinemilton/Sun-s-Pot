using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerAI : MonoBehaviour
{
    [SerializeField] Customer customer;
    
    Player player;

    [Header("Mood")]
    [SerializeField] float maxMoodTime = 10;
    [SerializeField] float currMoodTime = 0;
    public enum MoodState {HAPPY, UPSET, ANGRY, LEAVE};
    [SerializeField] MoodState currMood = MoodState.HAPPY;

    [Header("Boundary")]
    [SerializeField] Vector3 linePosition;

    [Header("Ranges")]
    [SerializeField] float maxEatTime = 10;
    [SerializeField] float currEatTime = 0;
    [SerializeField] float orderingTime = 10;
    [SerializeField] float currOrderTime = 0;

    [Header("Restuarant State")]
    [SerializeField] string restuarantState = "Enter State";

    public delegate void RestuarantState();
    RestuarantState currentState;

    Table currTable;
    Recipe order;

    bool playerTakeOrder = false;
    bool hasCalled = false;
    bool hasOrder = false;


    void Start()
    {
        ChangeState(EnterState);
        linePosition = CustomerGenerator.singleton.enterPos;
    }

    void Update()
    {
        AITick();
    }

    void AITick(){
        currentState();
        
        currMoodTime += Time.deltaTime;
        if(currMoodTime >= maxMoodTime){
            IncreaseMood();
        }

        if(currMood == MoodState.LEAVE){
            if(currTable != null) currTable.SetUnoccupied();
            ChangeState(LeavingState);
            restuarantState = "Leaving State";
        }
    }

    void ChangeState(RestuarantState newState){
        currentState = newState;
        if(currentState != LeavingState && currentState != DestroyState) ResetMood();
    }

    void EnterState(){
        restuarantState = "EnterState";
        linePosition = CustomerGenerator.singleton.enterPos;
        //move from off camera to end of line
        customer.MoveToward(linePosition);
        
    }

    void SeatingState(){
        //follow player
        customer.MoveToward(player.transform.position);
    }

    void AttemptToSeat(){
        currTable = customer.table;
        if(currTable != null){
            if(!currTable.IsOccupied()){
                customer.Seat(currTable);
                currTable = customer.table;
                ChangeState(OrderingState);
                restuarantState = "Ordering State";
            }
        }
    }

    void OrderingState(){
       //customer position at seat postion
       if(currTable != null){
        currTable.SeatCustomer(customer);
       }
       else{
        Debug.Log("The table is null");
        return;
       }

       //wait 10s before ordering
       if(currOrderTime < orderingTime){
        ResetMood();
        currOrderTime += Time.deltaTime;
        return;
       }
       else{
        hasOrder = true;
       }
       
        //wave down animation + sound
        if(!hasCalled){
            CustomerGenerator.singleton.customerCall.Play();
            hasCalled = true;
        }
        customer.Wave();

        if(playerTakeOrder){
            customer.ResetBody(); //remove wave
             //choose from menu and create an order
            Random.InitState(173402);
            List<Recipe> recipes = MenuManager.singleton.unlockedRecipes;

            order = recipes[Random.Range(0, recipes.Count)];
            if(order != null){
                //ui bubble with order
                currTable.SetOrder(order);
                customer.SetOrder(order);
                ChangeState(FoodWaitingState);
            }
        }

    }

    void FoodWaitingState(){
        restuarantState = "Food Waiting State";
    
        if(currTable.orderPlaced){
            Debug.Log(currTable.orderPlaced);
            ChangeState(EatingState);
        }
        
    }

    void EatingState(){
        restuarantState = "Eating State";
        ResetMood();
        currEatTime += Time.deltaTime;
        if(currEatTime < maxEatTime){
            customer.Eat();
        }
        else{
            customer.ResetBody();
            //leave money
            customer.Pay(currTable, order);
            Debug.Log("Customer has paid");
            ChangeState(LeavingState);
        }
        
    }

    void LeavingState(){
        restuarantState = "Leaving State";
        customer.RemoveOrder();
        //leave table
        if(customer.transform.position.x >= 15){
            ChangeState(DestroyState);
        }
        
        customer.MoveToward(new Vector3(20,-5,0));
    }

    void DestroyState(){
        CustomerGenerator.singleton.customersCount--;
        Destroy(customer.GameObject());
    }

    void IncreaseMood(){
        currMood++;
        currMoodTime = 0;
        customer.DecrementTip();
        //change prefab to more angy
        customer.SetMoodHead(currMood);
    }

    void ResetMood(){
        currMood = MoodState.HAPPY;
        currMoodTime = 0;
        //change prefab back to happy
        customer.SetMoodHead(currMood);
    }

    public void PlayerInteraction(Player player){  
        this.player = player;
        if(currentState == EnterState){
            CustomerGenerator.singleton.TakeCustomerFromLine();
            ChangeState(SeatingState);
            restuarantState = "Seating State";
        }
        else if(currentState == SeatingState){
            AttemptToSeat();

        }
        else if(currentState == OrderingState){
            if(hasOrder) playerTakeOrder = true;
            Debug.Log("Player take order");
             
        }
        else if(currentState == FoodWaitingState){
            Debug.Log("current table order placed: " + currTable.orderPlaced);
            if(currTable.orderPlaced) ChangeState(EatingState);

        }
        else if(currentState == LeavingState){

        }
        else Debug.Log("State unknown");
    }

    
}