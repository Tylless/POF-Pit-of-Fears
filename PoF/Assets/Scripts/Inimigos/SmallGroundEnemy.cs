using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmallGroundEnemy : MonoBehaviour
{
    [Header("PatrolPoints")]
    public Transform[] patrolPoints;
    [Header("Values")]
    public int currentPoint;
    public bool canMove;
    public float waitCounter;
    public float waitAtPoint;
    public bool onRange;
    public float actualSpeed;
    public float patrolSpeed;
    public float chaseSpeed;
    public bool chasing;
    public bool patrolling;
    public bool onChaseArea;
    [Header("Components")]
    public static SmallGroundEnemy instance;
    public GameObject CL;
    public Rigidbody2D RB;
    public LayerMask chaseArea;
    public Animator anim;
    public SpriteRenderer sr;
    public Transform checkPoint;
    public Collider2D col;
    public PlayerMovement p;
    public bool killing;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    
    void Start()
    {
        p = FindFirstObjectByType<PlayerMovement>();
        waitCounter = waitAtPoint;
        foreach(Transform pPoint in patrolPoints)
       {
            pPoint.SetParent(null);
       }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PauseScreen.instance.Paused)
        {
            canMove = false;
        }else
        {
            canMove = true;
        }
        
        if(canMove)
    {
        if(!killing)
       {   
        CheckTrigger();
        ChaseAndPatrol();
        if(patrolling)
        {
            Patrol();
            anim.SetBool("Hunting", false);
            sr.sortingOrder = 12;
            col.gameObject.SetActive(false);
            CL.SetActive(false);
        }
        if(chasing)
        {
            Chase();
            anim.SetBool("Hunting", true);
            sr.sortingOrder = 12;
            col.gameObject.SetActive(true);
            CL.SetActive(true);
        }
        }else
       {
        RB.velocity = Vector2.zero;
       }
    }else
    {
        RB.velocity = Vector2.zero;
    }
    }
    public void CheckTrigger()
    {
        onChaseArea = Physics2D.OverlapCircle(checkPoint.transform.position, .01f, chaseArea);
    }   
    public void Patrol()
    {
        if(Mathf.Abs(transform.position.x - patrolPoints[currentPoint].position.x) > .2f)
        {
            if(transform.position.x < patrolPoints[currentPoint].position.x)
            {
                RB.velocity = new Vector2(actualSpeed, RB.velocity.y);
                transform.localScale = new Vector3(.4f, .4f, .4f);
                anim.SetBool("Moving", true);
            }else
            {
                RB.velocity = new Vector2(-actualSpeed, RB.velocity.y);
                transform.localScale = new Vector3(-.4f, .4f, .4f);
                anim.SetBool("Moving", true);
            }
        }else
        {
            RB.velocity = new Vector2(0f, RB.velocity.y);
            anim.SetBool("Moving", false);
            waitCounter -= Time.deltaTime;
            if(waitCounter <= 0)
            {
                waitCounter = waitAtPoint;
                currentPoint++;
                if(currentPoint >= patrolPoints.Length)
                {
                 currentPoint = 0;
                }
            }
            
        }
    }
    public void Chase()
    {
        if(transform.position.x > p.gameObject.transform.position.x)
        {
            RB.velocity = new Vector2(-actualSpeed, RB.velocity.y);
            transform.localScale = new Vector3(-.4f, .4f, .4f);
            anim.SetBool("Moving", true);
        }else if (transform.position.x < p.gameObject.transform.position.x)
        {
            RB.velocity = new Vector2(actualSpeed, RB.velocity.y);
            transform.localScale = new Vector3(.4f, .4f, .4f);
            anim.SetBool("Moving", true);
        }
    }
    public void ChaseAndPatrol()
    {
       
        if(onRange && p.visibility > 0 && onChaseArea)
        {
            chasing = true;
            patrolling = false;
        }
         if(p.visibility <= 0)
        {
            patrolling = true;
            chasing = false;
        }
        if(!onRange)
        {
            patrolling = true;
            chasing = false;
        }
        if(!onChaseArea)
        {
            patrolling = true;
            chasing = false;
        }
        if(patrolling)
        {
            actualSpeed = patrolSpeed;
        }
        if(chasing)
        {
            actualSpeed = chaseSpeed * GameDificultLevel.instance.speedMultiplier;
        }
       
    }
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            onRange = true;            
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            onRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            onRange = false;
        }
        
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
        patrolling = false;
        chasing = false;
        killing = true;
        if(PlayerMovement.instance.gameObject.transform.position.x > this.transform.position.x)
        {
            transform.localScale = new Vector3(.4f, .4f, .4f);
            PlayerMovement.instance.gameObject.transform.localScale = new Vector2(0.5f , 0.5f);
        }
        if(PlayerMovement.instance.gameObject.transform.position.x < this.transform.position.x)
        {
            transform.localScale = new Vector3(-.4f, .4f, .4f);
            PlayerMovement.instance.gameObject.transform.localScale = new Vector2(-0.5f , 0.5f);
        }
        if(PlayerMovement.instance.onGround)
        {
            anim.SetTrigger("Kill");
            CallDeath();
        }else
        {
            anim.SetTrigger("KillAir");
        }
        
        
        
    }       
    public void StopKilling()
    {
        killing = false;
    }

    public void CallDeath()
    {
        PlayerMovement.instance.Death();
    }
    
   
    
}
