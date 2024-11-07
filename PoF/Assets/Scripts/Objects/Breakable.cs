using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using System;
public class Breakable : MonoBehaviour
{
    public static Breakable instance;
    public GameObject BreakEffect;
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
    public void SummonPar(float xSpeed)
    {
        GameObject Eff = Instantiate(BreakEffect);
        Eff.transform.position = this.transform.position;
        Vector2 fall = new Vector2(xSpeed, 4f);
        Eff.GetComponent<Rigidbody2D>().AddForce(fall, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "DealDamage")
        {
        Destroy();
        SummonPar(1f);
        SummonPar(-1f);
        SummonPar(1.5f);
        SummonPar(-1.5f);
        }
    }
    public void GoToSpawn()
    {
     transform.position = spawn.position;
     this.gameObject.SetActive(true); 
    }
    
    
}
