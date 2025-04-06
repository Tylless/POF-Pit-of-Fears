using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScreen : MonoBehaviour
{
    public GameObject optionsScreen;
    public GameObject mainPage;
    public GameObject PScreen;
    public GameObject AudioScreen;
    public GameObject ControlsScreen;
    public bool Paused;
    public static PauseScreen instance;
    public RuntimeAnimatorController animCon;
    public AudioClip ConfirmAudio;
    public AudioClip DeclineAudio;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start() {
        CloseScreen();
        Cursor.visible = false;
    }
    public void OptionsScreenOn()
    {
        optionsScreen.SetActive(true);
        mainPage.SetActive(false);
        AudioController.instance.TocarSFX(ConfirmAudio);
    }

    public void Respawn()
    {
        AudioController.instance.TocarSFX(ConfirmAudio);
        RespawnController.instance.Respawn();
        CloseScreen();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                CloseScreen();
            }else
            { 
                OpenScreen();
            }
        }
        if(Paused)
        {
            PlayerMovement.instance.BlockMovment();
            PlayerMovement.instance.anim.runtimeAnimatorController = null;
            CursorManager.instance.PauseOn = true;
        }
        if(!Paused)
        {
            CursorManager.instance.PauseOn = false;
        }
         
        
            

    }

    public void GoToMainPage()
    {
        optionsScreen.SetActive(false);
        mainPage.SetActive(true);
        AudioScreen.SetActive(false);
        ControlsScreen.SetActive(false);
    }
    public void GoToMainPageAudio()
    {
        AudioController.instance.TocarSFX(DeclineAudio);
        optionsScreen.SetActive(false);
        mainPage.SetActive(true);
        AudioScreen.SetActive(false);
        ControlsScreen.SetActive(false);
    }
    public void OpenScreen()
    {
        Cursor.visible = true;
        PScreen.SetActive(true);
        GoToMainPage();
        Paused = true;
        
    }

    public void CloseScreen()
    {
        
        Cursor.visible = false;
        PScreen.SetActive(false);
        Paused = false;
        PlayerMovement.instance.UnblockMovment();
        PlayerMovement.instance.anim.runtimeAnimatorController = animCon;
        
    }
    public void BackToMenu()
    {
        AudioController.instance.TocarSFX(DeclineAudio);
        SceneManager.LoadScene("Menu");
        Menu.instance.onStartPage = false;
    }
    public void BackToOptionsPage()
    {
        AudioController.instance.TocarSFX(DeclineAudio);
        optionsScreen.SetActive(true);
        AudioScreen.SetActive(false);
        ControlsScreen.SetActive(false);
    }
    public void OpenAudio()
    {
        AudioController.instance.TocarSFX(ConfirmAudio);
        optionsScreen.SetActive(false);
        AudioScreen.SetActive(true);
        
    }
    public void OpenControl()
    {
        AudioController.instance.TocarSFX(ConfirmAudio);
        optionsScreen.SetActive(false);
        ControlsScreen.SetActive(true);
        
    }
}
