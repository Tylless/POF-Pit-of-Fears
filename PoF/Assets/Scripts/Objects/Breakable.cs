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
  
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        if(RespawnController.instance.spawn == 1f)
        {
            Destroy(this.gameObject);
        }
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
        DestroyThis();
        SummonPar(1f);
        SummonPar(-1f);
        SummonPar(1.5f);
        SummonPar(-1.5f);
        }
    }
    
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
    
}
