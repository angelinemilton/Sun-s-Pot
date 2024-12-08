using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] float lowerBound = 11.16f;
    [SerializeField] float upperBound = -11.16f;
    [SerializeField] float speed = 2;
    [SerializeField] bool movingLeft = true;
    [SerializeField] bool UpDown = false;

    void Update()
    {
        if(!UpDown){
            if(transform.position.x >= lowerBound) movingLeft = true;
            else if(transform.position.x <= upperBound) movingLeft = false;

            int direction = -1;
            if(!movingLeft) direction = 1;

            transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
        }
        else{ //mopve up down
            if(transform.position.y >= lowerBound) movingLeft = true;
            else if(transform.position.y <= upperBound) movingLeft = false;

            int direction = -1;
            if(!movingLeft) direction = 1;

            transform.position += new Vector3(0, direction * speed * Time.deltaTime, 0);

        }
       
       
    }
}
