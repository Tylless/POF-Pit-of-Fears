using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Menu : MonoBehaviour
{

    public void Close()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    
}
