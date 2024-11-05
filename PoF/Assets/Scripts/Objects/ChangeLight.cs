using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    public float ilu;
     private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "LightCol")
        {
         PlayerLight.instance.iluminação = ilu;
        }
    
    }
}
