using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] Transform apex;
    [SerializeField] Transform sunset;
    bool isSetting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSetting){
            MoveTowards(apex.position);
            if(Mathf.Abs(apex.position.x - transform.position.x) < 0.1) isSetting = true;
        }
        else{
            MoveTowards(sunset.position);
        }
    }

    void Move(Vector3 movement){
         transform.position += movement * speed * Time.deltaTime;
    }

    void MoveTowards(Vector3 goalPos){
        goalPos.z = 0;
        goalPos += new Vector3(-.5f, 0, 0);
        Vector3 direction = goalPos - transform.position;
        if(Vector3.Distance(transform.position, goalPos) < 0.1f){
            return;
        }
        Move(direction.normalized);
    }
}
