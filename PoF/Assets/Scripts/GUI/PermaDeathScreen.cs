using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermaDeathScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Apagar Save
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Application.Quit();
            Debug.Log("Morreu, trouxa KKKKKKKK");
        }
    }
}
