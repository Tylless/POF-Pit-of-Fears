using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderQueenBoss : MonoBehaviour
{
    public Rigidbody2D RB;
    public float speed;
    public static SpiderQueenBoss instance;
    public float stunTime;
    public bool stunned;
    public float timeStunned;
    public float ActualStunTime;
    public float chaseDir;
    public bool idle;
    public Animator anim;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        idle = false;
    }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(RespawnController.instance.spawn == 1f)
        {
            
            Destroy(this.gameObject);
            
        }
        if(!idle)
        {
        if(stunned) 
        {
            Stun();       
        }else
        {
            
            Hunt();
        }
        }
    }
    public void Idle()
    {
        anim.SetBool("Hunting", false);
        anim.SetBool("Stunned", false);
        idle = true;
        RB.velocity = Vector2.zero;
    }

    public void Stun()
    {
        RB.velocity = new Vector2(0f, RB.velocity.y);
        if(timeStunned > 0)
        {
        timeStunned -=Time.deltaTime * 3f;
        anim.SetBool("Stunned", true);
        }
        if(timeStunned <= 0)
        {
            timeStunned = 0f;
            stunned = false;
            anim.SetBool("Stunned", false);
        }
        
    }
    public void Hunt()
    {
        RB.velocity = new Vector2(speed * chaseDir, RB.velocity.y);
        transform.localScale = new Vector3(chaseDir * 0.6f, 0.6f, 0.6f);
        anim.SetBool("Hunting", true);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
         if (other.gameObject.tag == "Player")
        {
            Kill();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
         if (other.gameObject.tag == "DestroyBoss")
        {
            Destroy(this.gameObject);
        }
        
    }
    public void Kill()
    {
        Idle();
        PlayerMovement.instance.BeSmashed();
    }
    public void GetStunned()
    {
        ActualStunTime = stunTime * GameDificultLevel.instance.stunMultiplier;
        timeStunned = ActualStunTime;
        stunned = true;
    }

    
}
