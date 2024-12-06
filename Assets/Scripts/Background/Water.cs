using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] float leftX = 11.16f;
    [SerializeField] float rightX = -11.16f;
    [SerializeField] float speed = 2;
    [SerializeField] bool movingLeft = true;

    void Update()
    {
        if(transform.position.x >= leftX) movingLeft = true;
        else if(transform.position.x <= rightX) movingLeft = false;

       int direction = -1;
       if(!movingLeft) direction = 1;

       transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
    }
}
