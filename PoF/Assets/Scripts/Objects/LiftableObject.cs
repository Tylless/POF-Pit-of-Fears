using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using Unity.Mathematics;
public class LiftableObject : MonoBehaviour

{
    public static LiftableObject instance;
    public bool onGround;
    public GameObject liftPointRight;
    public GameObject liftPointLeft;
    public GameObject BreakEffect;
    
    public bool beingLifted;
    public SpriteRenderer SR;
    public Rigidbody2D RB;
    public bool canBeLifted;
    public bool canBeThrown;
    public bool onRange;
    public GameObject trigger;
    public GameObject hb;
    public GameObject lhb;
    
    public bool beingThrown;
    public float throwSpeed;
    public LayerMask ground;
    public bool RP;
    public bool LP;
    public AudioSource audioPlayer;
    public AudioClip impact;
    public GameObject destroyEffect;
    
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

    }
     public void SummonPar(float xSpeed)
    {
        GameObject Eff = Instantiate(BreakEffect, new Vector3(this.transform.position.x, this.transform.position.y, 
            this.transform.position.z), Quaternion.identity);
        Eff.transform.position = this.transform.position;
        Vector2 fall = new Vector2(xSpeed, 4f);
        Eff.GetComponent<Rigidbody2D>().AddForce(fall, ForceMode2D.Impulse);
    }

    void Update()
    {
        
        CheckGround();
        if(!PlayerMovement.instance.lifting)
        {
            beingLifted = false;
        }
        if(PlayerMovement.instance.crawling)
        {
           trigger.SetActive(false);
        }else
        {
            trigger.SetActive(true);
        }
        BeLifetd();
        BeThrown();
        if(beingLifted)
        {
           
            transform.position = new Vector3(PlayerMovement.instance.liftPoint.transform.position.x, PlayerMovement.instance.liftPoint.transform.position.y + 0.2f, PlayerMovement.instance.liftPoint.transform.position.z);
            RB.isKinematic = true;
            canBeLifted = false;
            canBeThrown = true;
            hb.SetActive(false);
            lhb.SetActive(true);
            SR.sortingOrder = 13;
            
            
        }
        if(!beingLifted)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            SR.sortingOrder = 10;
            RB.isKinematic = false;
            canBeThrown = false;
            hb.SetActive(true);
            lhb.SetActive(false);        
        }
        
            if(!beingThrown)
            RB.velocity = new Vector2(0f, RB.velocity.y);
            

            if(RespawnController.instance.spawn == 1f)
        {
            Destroy(this.gameObject);
        }
            }
    public void CheckGround()
    {
        RP = Physics2D.OverlapCircle(liftPointRight.transform.position, .01f, ground);
        LP = Physics2D.OverlapCircle(liftPointLeft.transform.position, .01f, ground);
        if(RP || LP || RP && LP)
        {
            onGround = true;
        }else
        {
            onGround = false;
        }
    }
   
    public void BeLifetd()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
        
        if(beingLifted)
        {
            beingLifted = false;
            
        }else
        
            if(canBeLifted && PlayerMovement.instance.liftO == 0)
        {
            beingLifted = true;
            PlayerMovement.instance.liftO ++;
        }
        
        }
         if(onRange && PlayerMovement.instance.canLift)
        {
            canBeLifted = true;
        }else 
        {
            canBeLifted = false;
        }
        
    }
    public void BeThrown()
    {
        if(canBeThrown && Input.GetKeyDown(KeyCode.R))
        {
            
                beingThrown = true;
                RB.isKinematic = false;
                float throwforceX = PlayerMovement.instance.throwForceX;
                float throwforceY = PlayerMovement.instance.throwForceY;
                Vector2 throwf = new Vector2(2 * throwforceX * PlayerMovement.instance.facingDir, throwforceY);
                RB.AddForce(throwf, ForceMode2D.Impulse);
                
            
        }
        if(beingThrown)
        {
            
            if(RB.velocity.x > 0)
            {
                throwSpeed = RB.velocity.x - Time.deltaTime * 10;
            RB.velocity = new Vector2(throwSpeed, RB.velocity.y);
                if(throwSpeed <= 0)
            {
                beingThrown = false;
                throwSpeed = 0;
            }
            }
            if(RB.velocity.x < 0)
            {
                throwSpeed = RB.velocity.x + Time.deltaTime * 10;
            RB.velocity = new Vector2(throwSpeed, RB.velocity.y);
                if(throwSpeed >= 0)
            {
                beingThrown = false;
                throwSpeed = 0;
            }
            }
            PlayerMovement.instance.canLift = false;
            canBeLifted = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D p) {
        if(p.gameObject.tag == "Player" && onGround || p.gameObject.tag == "Player" && p.gameObject.tag != "Player" && onGround) 
        {
            
            onRange = true;
            
            
        }
       
        
    }
     private void OnTriggerStay2D(Collider2D p) {
        if(p.gameObject.tag == "Player" && onGround || p.gameObject.tag == "Player" && p.gameObject.tag != "Player" && onGround) 
        {
            
                onRange = true;
            
            
        }
       
        
    }

    private void OnTriggerExit2D(Collider2D p) {
        
        if(p.tag == "Player")
        {
            onRange = false;
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "DamageTaker")
        {
            GameObject audioef = Instantiate(destroyEffect, new Vector3(this.transform.position.x, this.transform.position.y, 
            this.transform.position.z), Quaternion.identity);
            Destroy(audioef.gameObject, 1.5f);
            Explode();
        
        }
        if(other.gameObject.tag == "Ground" ||other.gameObject.tag == "Pushable")
        {
            
            
                audioPlayer.PlayOneShot(impact);
            
            
        }
    }
    
    
    
    public void Explode()
    {
        
        Destroy(this.gameObject);
        SummonPar(.5f);
        SummonPar(-.5f);
        }
    }

