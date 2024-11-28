using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PercentageSlider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI percentageText;
    [SerializeField] Slider slider;

    void Awake()
    {
        SetPercentage();
    }
    public void SetPercentage(){
        percentageText.text = (slider.value * 100).ToString("F0") + "%";
    }

}
