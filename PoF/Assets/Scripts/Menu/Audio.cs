using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioScreen : MonoBehaviour
{
    public AudioMixer theMixer;
    
    public Slider masterSlider, musicSlider, sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVol");
        theMixer.SetFloat("MasterVol", masterSlider.value);

        musicSlider.value = PlayerPrefs.GetFloat("MusicVol");  
        theMixer.SetFloat("MusicVol", musicSlider.value);

        sfxSlider.value = PlayerPrefs.GetFloat("SFXVol");
        theMixer.SetFloat("SFXVol", sfxSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMaster()
    {
       

        theMixer.SetFloat("MasterVol", masterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
   public void setMusic()
    {
        

        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }public void setSFX()
    {
        

        theMixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }

    

    
}
