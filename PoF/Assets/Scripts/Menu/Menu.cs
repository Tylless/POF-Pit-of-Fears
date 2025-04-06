using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Utilities;
public class Menu: MonoBehaviour
{
    [Header("Menus")]
    public GameObject mainPage;
    public GameObject startPage;
    public GameObject optionsPage;
    public GameObject audioPage;
    public GameObject imagePage;
    public GameObject controlsPage;
    public GameObject newPage;
    public GameObject quitPage;
    public GameObject languagePage;
    public GameObject loadPage;
    public GameObject loadButton;
    public GameObject UBG;
    public GameObject SBG;
    public Image Logo;
    public Image Text;
    public Color black;
    public Color white;
    public static Menu instance;
    [Header("Sound")]
    public AudioClip OpenAudio;
    public AudioClip CloseAudio;

    [Header("Values")]
    public bool onStartPage;
    public bool thereIsASave;

    private void Awake() {
        onStartPage = true;
        if(instance = null)
        {
            instance = this;
        }
        
    }
    void Start()
    {
        Language.instance.selectedlang = PlayerPrefs.GetInt("Language"); 
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[Language.instance.selectedlang];
    }
    private void Update() {
        if(onStartPage)
        {
            languagePage.SetActive(false);
            quitPage.SetActive(false);
            mainPage.SetActive(false);
            optionsPage.SetActive(false);
            controlsPage.SetActive(false);
            imagePage.SetActive(false);
            audioPage.SetActive(false);
            newPage.SetActive(false);
            loadPage.SetActive(false);
            startPage.SetActive(true);
            UBG.SetActive(false);
            SBG.SetActive(true);
            Logo.color = Color.black;
            Text.color = Color.black;
        }
        if(!onStartPage)
        {
            startPage.SetActive(false);
            UBG.SetActive(true);
            SBG.SetActive(false);
            Logo.color = Color.white;
            Text.color = Color.white;
        }
        if(onStartPage && Input.anyKeyDown)
        {
            onStartPage = false;
            mainPage.SetActive(true);
            
        }
        if(thereIsASave)
        {
            loadButton.SetActive(true);
        }
        if(!thereIsASave)
        {
            loadButton.SetActive(false);
        }
    }

    public void NewPage()
    {
        newPage.SetActive(true);
        mainPage.SetActive(false);
        AudioController.instance.TocarSFX(OpenAudio);
    }
    public void GoToStart()
    {
        onStartPage = true;
        
    }
    public void LoadPage()
    {
        loadPage.SetActive(true);
        mainPage.SetActive(false);
        AudioController.instance.TocarSFX(OpenAudio);
    }
    public void ImagePage()
    {
        imagePage.SetActive(true);
        optionsPage.SetActive(false);
        AudioController.instance.TocarSFX(OpenAudio);
    }
    public void AudioPage()
    {
        audioPage.SetActive(true);
        optionsPage.SetActive(false);
        AudioController.instance.TocarSFX(OpenAudio);
    }
    public void LanguagePage()
    {
        languagePage.SetActive(true);
        optionsPage.SetActive(false);
        AudioController.instance.TocarSFX(OpenAudio);
    }
    public void ControlPage()
    {
        controlsPage.SetActive(true);
        optionsPage.SetActive(false);
        AudioController.instance.TocarSFX(OpenAudio);
    }
    public void OptionsPage()
    {
        mainPage.SetActive(false);
        optionsPage.SetActive(true);
        AudioController.instance.TocarSFX(OpenAudio);
    }
    public void BackToOptionsPage()
    {
        controlsPage.SetActive(false);
        languagePage.SetActive(false);
        imagePage.SetActive(false);
        audioPage.SetActive(false);
        optionsPage.SetActive(true);
        AudioController.instance.TocarSFX(CloseAudio);
    }
    public void BackToMainPage()
    {
        mainPage.SetActive(true);
        optionsPage.SetActive(false);
        newPage.SetActive(false);
        loadPage.SetActive(false);
        quitPage.SetActive(false);
        AudioController.instance.TocarSFX(CloseAudio);
    }
    public void QuitPage()
    {
        mainPage.SetActive(false);
        quitPage.SetActive(true);
        AudioController.instance.TocarSFX(OpenAudio);
    }
    public void QuitGame()
    {
        AudioController.instance.TocarSFX(CloseAudio);
        Application.Quit();
        Debug.Log("Quitou");
    }
    
}
