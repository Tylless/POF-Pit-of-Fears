using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Menu: MonoBehaviour
{
    [Header("Menus")]
    public GameObject mainPage;
    public GameObject startPage;
    public GameObject optionsPage;
    public GameObject audioPage;
    public GameObject imagePage;
    public GameObject controlsPage;
    public GameObject savesPage;
    public GameObject quitPage;
    public GameObject languagePage;

    [Header("Values")]
    public bool onStartPage;

    private void Awake() {
        onStartPage = true;
         
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
            languagePage.SetActive(false);
            startPage.SetActive(true);
        }
        if(!onStartPage)
        {
            startPage.SetActive(false);
        }
    }
}
