using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    [SerializeField] TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        Resolution currRes = Screen.currentResolution;
        for(int i = 0; i < resolutions.Count(); i++){
            string resolutionString = resolutions[i].width + "x" + resolutions[i].height;
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutionString));
            if(currRes.Equals(resolutions[i])){
                resolutionDropdown.value = i;
            }
        }
    }

    public void SetResolution(){
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, true);
    }

}
