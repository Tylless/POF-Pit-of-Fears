using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using System;
public class Breakable : MonoBehaviour
{
    public static Breakable instance;
    public Animator anim;
    public GameObject col;
    public Transform spawn;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        
    }
    public void Destroy()
    {
        this.gameObject.SetActive(false);
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "DealDamage")
        {
        anim.SetTrigger("Break");
        
        }
    }
    public void GoToSpawn()
    {
     transform.position = spawn.position;
     this.gameObject.SetActive(true); 
    }
    
    
}
