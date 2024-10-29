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
    enum MoodState {HAPPY, UPSET, ANGRY, LEAVE};
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
            ChangeState(LeavingState);
            restuarantState = "Leaving State";
        }
    }

    void ChangeState(RestuarantState newState){
        currentState = newState;
        if(currentState != LeavingState && currentState != DestroyState) ResetMood();
    }

    void EnterState(){
        linePosition = CustomerGenerator.singleton.enterPos;
        //move from off camera to end of line
        customer.MoveToward(linePosition);
        
        
    }

    void SeatingState(){
        
        //follow player
        customer.MoveToward(player.transform.position);
    }

    void AttemptToSeat(){
        if(customer.inTableRange){
            currTable = customer.table;
            if(!currTable.IsOccupied()){
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

        //wave down animation + sound
        customer.Wave();

        if(playerTakeOrder){
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
        //ui bubble with order
        if(currTable.orderPlaced){
            ChangeState(EatingState);
        }
        
    }

    void EatingState(){
        restuarantState = "Eating State";
        ResetMood();
        currEatTime += Time.deltaTime;
        if(currEatTime < maxEatTime){
            customer.Eat();
            return;
        }
        //leave money
        customer.Pay(currTable, order);
        Debug.Log("Customer has paid");
        ChangeState(LeavingState);
            
        
        
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
    }

    void ResetMood(){
        currMood = MoodState.HAPPY;
        currMoodTime = 0;
        //change prefab back to happy
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
            playerTakeOrder = true;
            Debug.Log("Player take order");
             
        }
        else if(currentState == FoodWaitingState){
            if(currTable.orderPlaced) ChangeState(EatingState);

        }
        else if(currentState == LeavingState){
        }
        else Debug.Log("State unknown");
    }

    public void PlayerPlaceOrder(){
        ChangeState(EatingState);
        customer.RemoveOrder();
    }

    
    
}