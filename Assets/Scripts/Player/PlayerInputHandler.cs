using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Player player1;
    [SerializeField] Player player2;

    [SerializeField] Pot pot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleInteractions();
        
    }

    void HandleMovement(){
        //player1
        if(Input.GetKey(KeyCode.W)){
            player1.Move(Vector3.up);
        }
        else if(Input.GetKey(KeyCode.A)){
            player1.Move(Vector3.left);
        }
        else if(Input.GetKey(KeyCode.S)){
            player1.Move(Vector3.down);
        }
        else if(Input.GetKey(KeyCode.D)){
            player1.Move(Vector3.right);
        }
        
        //player2
        if(Input.GetKey(KeyCode.UpArrow)){
            player2.Move(Vector3.up);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            player2.Move(Vector3.left);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            player2.Move(Vector3.right);
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
           player2.Move(Vector3.down);
        }
    }

    void HandleInteractions(){
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            //player1
            player1.OnInteraction();
        }
        if(Input.GetKeyDown(KeyCode.RightShift)){
            //player2
            player2.OnInteraction();
        }
    }

    
}
