using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolSlider;
    [SerializeField] Slider musicVolSlider;
    [SerializeField] Slider sfxVolSlider;
    // Start is called before the first frame update
    void Start()
    {
        masterVolSlider.value = PlayerPrefs.GetFloat("MasterVolume",0.5f);
        musicVolSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxVolSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SetMasterVolume(){
        SetVolume("MasterVolume", masterVolSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterVolSlider.value);
    }

     public void SetMusicVolume(){
        SetVolume("MusicVolume", musicVolSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolSlider.value);
    }

    public void SetSFXVolume(){
        SetVolume("SFXVolume", sfxVolSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolSlider.value);
    }

    void SetVolume(string groupName, float value){
        float adjustedVolume = Mathf.Log10(value) * 20;
        if(value == 0) adjustedVolume = -80;
        audioMixer.SetFloat(groupName, adjustedVolume);
    }
}
