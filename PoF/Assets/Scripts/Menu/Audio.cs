using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioScreen : MonoBehaviour
{
    public AudioMixer theMixer;
    public TMP_Text master, music, sfx;
    public Slider masterSlider, musicSlider, sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVol");
        master.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();
        theMixer.SetFloat("MasterVol", masterSlider.value);

        musicSlider.value = PlayerPrefs.GetFloat("MusicVol");  
        music.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        theMixer.SetFloat("MusicVol", musicSlider.value);

        sfxSlider.value = PlayerPrefs.GetFloat("SFXVol");
        sfx.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
        theMixer.SetFloat("SFXVol", sfxSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMaster()
    {
        master.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();

        theMixer.SetFloat("MasterVol", masterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
   public void setMusic()
    {
        music.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }public void setSFX()
    {
        sfx.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

        theMixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }

    

    
}
