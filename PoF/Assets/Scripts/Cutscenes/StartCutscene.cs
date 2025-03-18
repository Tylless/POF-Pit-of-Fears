using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public GameObject Cutscene;
    void SCutscene()
    {
     Cutscene.SetActive(true);   
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
        }
    }
}
