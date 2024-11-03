using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEGK : MonoBehaviour
{
    public SmallGroundEnemy SGE;
    void Start()
    {
        SGE = GetComponentInParent<SmallGroundEnemy>();
    }
     private void OnCollisionEnter2D(Collision2D p)
    {
         if (p.gameObject.tag == "Player")
        {
            Kill();
        }
    }
    public void Kill()
    {
        SGE.patrolling = false;
        SGE.chasing = false;
        if(PlayerMovement.instance.gameObject.transform.position.x > this.transform.position.x)
        {
            transform.localScale = new Vector3(-.4f, .4f, .4f);
        }
        if(PlayerMovement.instance.gameObject.transform.position.x < this.transform.position.x)
        {
            transform.localScale = new Vector3(.4f, .4f, .4f);
        }
        if(PlayerMovement.instance.onGround)
        {
            SGE.anim.SetTrigger("Kill");
        }else
        {
            SGE.anim.SetTrigger("KillAir");
        }
        
        PlayerMovement.instance.Die();
        
    }        
}
