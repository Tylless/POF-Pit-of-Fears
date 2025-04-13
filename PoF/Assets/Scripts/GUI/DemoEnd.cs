using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void STEAM()
    {
        Application.OpenURL("https://store.steampowered.com/app/3659880/Pit_of_Fears/");
    }
    public void YOUTUBE()
    {
        Application.OpenURL("https://www.youtube.com/@TelesGameStudios");
    }
    public void INSTAGRAM()
    {
        Application.OpenURL("https://www.instagram.com/telesgamestudios");
    }
    public void X()
    {
        Application.OpenURL("https://x.com/game_teles30256");
    }
    public void TIKTOK()
    {
        Application.OpenURL("https://www.tiktok.com/@teles.game.studio");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("KITA PORRA");
    }
}
