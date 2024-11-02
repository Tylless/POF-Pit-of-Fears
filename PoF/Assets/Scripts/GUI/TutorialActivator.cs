using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialActivator : MonoBehaviour
{
    public GameObject tutorial;
    public bool tutorialIsOn;
    
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorialIsOn){
            tutorial.SetActive(true);
        }else
        {
            tutorial.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "PlayerTuto"){
        tutorialIsOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
       if(other.gameObject.tag == "PlayerTuto"){
        tutorialIsOn = false;
       }
    }
}
