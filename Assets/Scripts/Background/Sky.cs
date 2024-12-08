using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [SerializeField] Gradient gradient;
    [SerializeField] float duration = 5f;
    [SerializeField] float percentage;
    [SerializeField] Material skyMaterial;
    [SerializeField] float offset = 0.1f;
    [SerializeField] float topGradientValue = 0;
    [SerializeField] float bottomGradientValue = .5f;
    float startTime;
    
    void Awake()
    {
        startTime = Time.deltaTime;
        topGradientValue = 0;
        bottomGradientValue = 0;
    }

    void Update()
    {
        float currTime = Mathf.Clamp01((Time.time - startTime) / duration);
        topGradientValue = currTime / duration * 100;
        bottomGradientValue = (currTime/ duration * 100) + offset;
        
        Color top = gradient.Evaluate(topGradientValue);
        Color bottom = gradient.Evaluate(bottomGradientValue);
        

        skyMaterial.SetColor("_TopColor", top);
        skyMaterial.SetColor("_BottomColor", bottom);
    }
}
