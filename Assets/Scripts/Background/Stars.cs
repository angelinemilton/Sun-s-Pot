using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField] float showTime;
    [SerializeField] float timer = 0;
    [SerializeField] float speed = 5f;
    [SerializeField] List<GameObject> stars;

    void Awake()
    {
        foreach(GameObject star in stars){
            star.GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= showTime){
            Color fade = new Color(1, 1, 1, (timer - showTime) *  speed / 255);
            foreach(GameObject star in stars){
                star.GetComponent<SpriteRenderer>().color = fade;
            }
        }
    }
}
