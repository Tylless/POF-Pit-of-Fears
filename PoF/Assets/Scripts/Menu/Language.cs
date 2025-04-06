using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Utilities;

public class Language : MonoBehaviour
{
    public string actlang;
    public static Language instance;
    public int selectedlang;
    public TMP_Text langLabel;
    public string[] languages;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
        LoadPrefs();
        UpdateLangLabel(selectedlang);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Right()
    {
        AudioController.instance.TocarSFX(Menu.instance.OpenAudio);
        selectedlang ++;
        if(selectedlang > languages.Length - 1)
        {
            selectedlang = 0;
        }
        UpdateLangLabel(selectedlang);
    }
    public void Left()
    {
        AudioController.instance.TocarSFX(Menu.instance.CloseAudio);
        selectedlang --;
        if(selectedlang < 0)
        {
            selectedlang = languages.Length - 1;
        }
        UpdateLangLabel(selectedlang);
    }
    public void UpdateLangLabel(int localeID)
    {
        actlang = languages[selectedlang].ToString();
        langLabel.text = actlang;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        SavePrefs();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("Language", selectedlang);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        selectedlang = PlayerPrefs.GetInt("Language");
    }
}
