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
    }

    public void Respawn()
    {
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
        SceneManager.LoadScene(1);
        Menu.instance.onStartPage = false;
    }
    public void BackToOptionsPage()
    {
        optionsScreen.SetActive(true);
        AudioScreen.SetActive(false);
        ControlsScreen.SetActive(false);
    }
    public void OpenAudio()
    {
        optionsScreen.SetActive(false);
        AudioScreen.SetActive(true);
        
    }
    public void OpenControl()
    {
        optionsScreen.SetActive(false);
        ControlsScreen.SetActive(true);
        
    }
}
