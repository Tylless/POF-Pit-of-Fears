using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alucinations : MonoBehaviour
{
    
    public GameObject Cutscene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Cutscene == null)
        {
            Destroy(this.gameObject);
        }
        
    }
    void Alu()
    {
     Cutscene.SetActive(true);   
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            Alu();
            Destroy(this.gameObject);
        }
    }
    
}
