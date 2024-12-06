using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform holdPosition;
    [SerializeField] GameObject heldItem;

    Customer customer;
    [SerializeField] bool inCustomerRange = false;

    [SerializeField] bool inIngredientBoxRange = false;
    IngredientBox box;

    [SerializeField] bool inPotRange = false;
    Pot pot;

    [SerializeField] bool inTableRange = false;
    [SerializeField] Table table;

    void Update()
    {
        transform.eulerAngles = Vector3.zero; 
    }

    public void Move(Vector3 movement){
        transform.position += speed * Time.deltaTime * movement.normalized;
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Customer")){ 
            customer = other.GetComponent<Customer>();
            if(customer == null){
                Debug.Log("Couldn't get customer script");
            }
            else{
                inCustomerRange = true;
                //glow customer
            }
        }
        else if(other.CompareTag("Table")){
            table = other.GetComponent<Table>();
            inTableRange = true;
            if(table == null){
                Debug.Log("Couldn't get table script");
            }
            
        }
        else if(other.CompareTag("IngredientBox")){
            inIngredientBoxRange = true;
            box = other.GetComponent<IngredientBox>();
            if(box == null){
                Debug.Log("Could not find box script");
            }
        }
        else if(other.CompareTag("Pot")){
            inPotRange = true;
            pot = other.GetComponent<Pot>();
            if(pot == null){
                Debug.Log("Could not find pot script");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Customer")){ 
            inCustomerRange = false;
            customer = null;
        }
        if(other.CompareTag("IngredientBox")){
            inIngredientBoxRange = false;
            box = null;
        }
        if(other.CompareTag("Pot")){
            inPotRange = false;
            pot = null;
        }
        if(other.CompareTag("Table")){
            inTableRange = false;
            table = null;
        }
    }

    public void OnInteraction(){
        if(inCustomerRange){
            CustomerInteraction();
        }
        else if(inIngredientBoxRange){
            IngredientBoxInteraction();
        }
        else if(inPotRange){
            PotInteraction();
        }
        else if(inTableRange){
            TableInteraction();
        }
        else{
            Debug.Log("No interactable object available");
        }
    }

    void CustomerInteraction(){
        CustomerAI ai = customer.GetComponentInChildren<CustomerAI>();
        if(ai != null){
            ai.PlayerInteraction(this);
        }
        else{
            Debug.Log("Customer AI is null");
        }
        
    }

    void IngredientBoxInteraction(){
        Ingredient ingredient = box.GetIngredient();
        if(ingredient != null) {
            Debug.Log("Found ingredient");
            Hold(ingredient.GameObject());
        }
    }

    void Hold(GameObject gameObject){
        if(heldItem == null){
            heldItem = Instantiate(gameObject, holdPosition.position, Quaternion.identity);
            heldItem.transform.SetParent(holdPosition);
        }
        
    }

    void PotInteraction(){
        Debug.Log("Interacting with pot");
        if(heldItem != null){
            if(heldItem.GetComponent<Ingredient>() != null){
                Destroy(holdPosition.GetChild(0).GameObject());
                pot.AddIngredient(heldItem.GetComponent<Ingredient>());
            }
            else Debug.Log("Could not find ingredient component of held item");
        }
        else{
            Recipe recipe = pot.TakeRecipe();
            if(recipe != null){
                heldItem = Instantiate(recipe.GameObject(), holdPosition.position, Quaternion.identity);
                heldItem.transform.SetParent(holdPosition);
            }
        }
    }

    void TableInteraction(){
        if(heldItem != null){
            if(heldItem.GetComponent<Recipe>() != null){
                if(table.ServeOrder(heldItem.GetComponent<Recipe>())) {
                    Destroy(heldItem.GameObject());
                }
            }
            else{
                Debug.Log("No recipe component found");
            }
        }
        else if(table.hasMoney){
            table.ClearTable();
        }
        else Debug.Log("No table interaction available");
    }

    
}
