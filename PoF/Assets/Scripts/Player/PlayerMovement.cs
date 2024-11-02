using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D PRB;
    public static PlayerMovement instance;
    public SpriteRenderer SR;
    public GameObject LeftFoot;
    public GameObject RightFoot;
    public GameObject liftPoint;
    public GameObject pushPoint;
    public Animator anim;
    

    
    [Header("Camera")]
    public CameraMovement CM;
    public GameObject cameraFollowObject;
    
    [Header("Talk to Enemies")]
    public float noise;
    public float visibility;

    [Header("Move")]
    public bool canMove;

    

    [Header("Looking at")]
    public bool facingRight;
    public float facingDir;

    [Header("Standing")]
    public bool canStand;
    public bool standing;
    
    [Header("Jump")]
    public float jumpForce;
    public bool falling;
    public bool canJump;
    public bool onGround;
    public bool leftFoot;
    public bool rightFoot;
    public bool jumping;
    public LayerMask ground;
    public float ExtraGravity;

    [Header("Walk/Run")]
    public float walkSpeed;
    public float runSpeed;
    public float moveSpeed;
    public bool running;
    public bool walking;
    

    [Header("Crawl")]
    public float crawlSpeed;
    public bool canCrawl;
    public bool crawling;

    
    
    

    [Header("Lift/Throw")]
    public float speedNerf;
    public float jumpForceNerf;
    public float throwForceX;
    public float throwForceY;
    public bool canLift;
    public bool lifting;
    public float liftO;
    public bool canThrow;
    
    [Header("Push")]
    public bool pushing;
    public float pushNerf;
    public bool canPush;
    public LayerMask PO;

    [Header("Hide")]
    public bool hiding;
    public bool canHide;
    public float hideNerf;
    public LayerMask HO;
    public Color hideColor;
    public Color normalColor;
    private void Awake()
    {
        if (instance == null)
        {
        instance = this;
        }
    }

    void Start()
    {
        facingRight = true;
        CM = cameraFollowObject.GetComponent<CameraMovement>();
        
    }

    void Update()
    {
        
        if(canMove)
        {
            
            Walk();
            Noise();
            Visibility();
            Stand();
            Crawl();
            Lift();
            Throw();
            TurnCheck();
            Jump();
            Push();
            Throw();
            Hide();
        }else
        {
            
            
        }
            CheckGround();
            CanPush();
            Animation();
            
            
        if(Input.GetKeyDown(KeyCode.Y))
        {
        RespawnController.instance.Respawn();           
        }
            
    }

    public void Die()
    {
        RespawnController.instance.Respawn();
    }
   

    public void Noise()
    {
        if(walking && standing)
        {
            noise = 3f;
        }
        if(walking && crawling)
        {
            noise = 0f;
        }
        if(walking && lifting)
        {
            noise = 2.1f;
        }
        if(running)
        {
            noise = 5f;
        }
        if (!running && !walking)
        {
            noise = 0f;
        }
        if(pushing && walking)
        {
            noise = 1.8f;
        }
        if(hiding && walking)
        {
            noise = 0.2f;
        }
        
    }
    public void Visibility()
    {
        if(standing)
        {
            visibility = 1;

        }
        if(crawling)
        {
            visibility = 0.5f;

        }
        if(lifting)
        {
            visibility = 0.7f;
        }
        if(pushing)
        {
            visibility = 0.8f;
        }
        if(jumping || falling)
        {
            visibility = 3f;
        }
        if(hiding)
        {
            visibility = 0;
        }
    }   
    public void TurnCheck()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if(moveInput > 0 && !facingRight)
        {
            Turn();
        }else if(moveInput < 0 && facingRight){
            Turn();
        }
    }
    public void Turn()
    {   
        
        if(facingRight)
        {
           Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
           transform.rotation = Quaternion.Euler(rotator);
           facingRight = !facingRight;
           facingDir = -1f;
           CM.CallTurn();
        }else
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
           transform.rotation = Quaternion.Euler(rotator);
           facingRight = !facingRight;
           facingDir = 1f;
           CM.CallTurn();
        }
    }
    public void Animation()
    {
        if(standing)
        {
            anim.SetBool("Standing?", true);
            anim.SetBool("Crawling?", false);
            anim.SetBool("Lifting?", false);
        }
        if(crawling)
        {
            anim.SetBool("Standing?", false);
            anim.SetBool("Crawling?", true);
            anim.SetBool("Lifting?", false);
        }
        if(lifting)
        {
            anim.SetBool("Standing?", false);
            anim.SetBool("Crawling?", false);
            anim.SetBool("Lifting?", true);
        }
        if(walking)
        {
            anim.SetBool("Moving?", true);
            anim.SetBool("Running?", false);
        }else
        {
            anim.SetBool("Moving?", false);
        }
        if(running)
        {
            anim.SetBool("Moving?", true);
            anim.SetBool("Running?", true);
        }else
        {
            anim.SetBool("Running?", false);
        }
        if(jumping)
        {
            anim.SetBool("Jumping?", true);
        }else
        {
            anim.SetBool("Jumping?", false);
        }
        if(falling)
        {
            anim.SetBool("Falling?", true);
        }else
        {
            anim.SetBool("Falling?", false);
        }
        if(pushing)
        {
            anim.SetBool("Pushing?", true);
        }else
        {
            anim.SetBool("Pushing?", false);
        }
        if(hiding)
        {
            anim.SetBool("Hiding?", true);
        }else
        {
            anim.SetBool("Hiding?", false);
        }
    }
    
    public void Walk()
    {
        float walkSide = Input.GetAxis("Horizontal");
        
       
        if(walkSide != 0)
        {
        if(lifting)
        {
            moveSpeed = walkSpeed * speedNerf;
            running = false;
            walking = true;
        }
        if(hiding)
        {
            moveSpeed = walkSpeed * hideNerf;
            running = false;
            walking = true;
        }
        if(standing)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = runSpeed;
                running = true;
                walking = false;

            }else
            {
                moveSpeed = walkSpeed;
                running = false;
                walking = true;
            }
        }
        if(crawling)
        {
            moveSpeed = crawlSpeed;
            walking = true;
            running = false;
        }
        if(pushing)
        {
            moveSpeed = walkSpeed * pushNerf;
            walking = true;
            running = false;
        }
        PRB.velocity = new Vector2(walkSide * moveSpeed, PRB.velocity.y);
        
        }else
        {
            walking = false;
            running = false;
            PRB.velocity = new Vector2(0f, PRB.velocity.y);
        }
            
        
    }
   
    public void Stand()
    {
        if(!crawling && !lifting && !pushing && !hiding)
        {
            standing = true;
        }else if(crawling || lifting || pushing || hiding)
        {
            standing = false;
        }
    }
    public void CheckGround()
    {
        rightFoot = Physics2D.OverlapCircle(RightFoot.transform.position, .01f, ground);
        leftFoot = Physics2D.OverlapCircle(LeftFoot.transform.position, .01f, ground);
        if(leftFoot || rightFoot || leftFoot && rightFoot)
        {
            onGround = true;
        }else
        {
            onGround = false;
        }
        
    }
    public void CanPush()
    {
        canPush = Physics2D.OverlapCircle(pushPoint.transform.position, .1f, PO);
    }
     public void Push()
    {
        if(lifting || crawling || jumping || falling || hiding)
        {
            canPush = false;
        }
        
        
        if(Input.GetKey(KeyCode.E)  && canPush && !pushing)
        {
            pushing = true;
        }
        if(!canPush)
        {
            pushing = false;
        }
        
        if(!Input.GetKey(KeyCode.E) && pushing)
        {
            pushing = false;
        }
        if(pushing)
        {
            canJump = false;
            canCrawl = false;
            canLift = false;
            
        }
    }
    public void Jump()
    {
        
        
        if(onGround && !crawling && !hiding && !pushing)
        {
            canJump = true;
        }
        if(crawling || hiding || pushing)
        {
            canJump = false;
        }
        if(onGround)
        {
            jumping = false;
            falling = false;
        }
        if(!onGround)
        {
            canJump = false;
        }
        if(PRB.velocity.y > 0)
        {
            jumping = true;
            falling = false;

        }
        if(PRB.velocity.y < 0)
        {
            falling = true;
            jumping = false;
            

        }
        if(onGround)
        {
            falling = false;
            jumping = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            if(!lifting)
            {
                Vector2 jforce = new Vector2(PRB.velocity.x, jumpForce);
                PRB.AddForce(jforce, ForceMode2D.Impulse);
            }else
            {
                Vector2 jforce = new Vector2(PRB.velocity.x, jumpForce * jumpForceNerf);
                PRB.AddForce(jforce, ForceMode2D.Impulse);
            }
            
            
        }
        if(jumping)
        {
            if(!Input.GetKey(KeyCode.Space))
            {
                Vector2 speed = PRB.velocity;
                 if(speed.y > 0)
                {
                Vector2 EG = (ExtraGravity * Vector2.down);
                PRB.AddForce(EG, ForceMode2D.Force);
                }
            }
        }
    }

    public void Lift()
    {
        if(liftO == 0)
        {
            lifting = false;
        }
        if(Input.GetKeyDown(KeyCode.E) && canLift && !lifting)
        {
            
            lifting = true;
            pushing = false;
           
        }else if (Input.GetKeyDown(KeyCode.E) && lifting)
        {
            lifting = false;
        }
        if(!lifting)
        {
            liftO = 0;
        }
               
    }

    public void Throw()
    {
        if(lifting)
        {
            canThrow = true;
            if(Input.GetKeyDown(KeyCode.R))
            {
                lifting = false;
            }
        }else
        {
            canThrow = false;
        }
    }

    public void Crawl()
    {
        if(!lifting && onGround)
        {
            canCrawl = true;
        }else
        {
            canCrawl = false;
        }
        if(Input.GetKey(KeyCode.S) && canCrawl)
        {
            crawling = true;
            standing = false;
            lifting = false;
            pushing = false;
        }else if(canStand && !Input.GetKey(KeyCode.S))
        {
            crawling = false;
        }else if(!canStand && !Input.GetKey(KeyCode.S) && crawling)
        {
            crawling = true;
        }else if (Input.GetKey(KeyCode.S) && !canCrawl)
        {
            crawling = false;
        }
        

    }
    public void Hide()
    {
        if(hiding)
        {
            canCrawl = false;
            canJump = false;
            canLift = false;
            canPush = false;
            canThrow = false;
            SR.color = hideColor;
        }
        if(!hiding)
        {
            SR.color = normalColor;
        }
        if(jumping || falling || lifting  || pushing || crawling)
        {
            canHide = false;
        }
        if(canHide && Input.GetKey(KeyCode.W))
        {
            hiding = true;
        }else
        {
            hiding = false;
        }
        

       
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == ("Ground"))
        {
            canStand = false;
        }
        
        if(other.gameObject.tag == ("Liftable") || other.gameObject.tag == ("Liftable") && other.gameObject.tag != ("Liftable"))
        {
            if(crawling || lifting || pushing || hiding)
            {
            }else if (!crawling && !lifting && !pushing && !hiding)
            {
                canLift = true;
            }
        }
        if(other.gameObject.tag == ("HideSpot") || other.gameObject.tag == ("HideSpot") && other.gameObject.tag != ("HideSpot"))
        {
            if(crawling || lifting || pushing)
            {}
            else if (!crawling && !lifting && !pushing){
                canHide = true;
            }
           
            
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        
        if(other.gameObject.tag == ("Ground") && other.gameObject.tag != ("Liftable"))
        {
            canStand = false;
        }
       
        if(other.gameObject.tag == ("Liftable") || other.gameObject.tag == ("Liftable") && other.gameObject.tag != ("Liftable"))
        {
            if(crawling || lifting || pushing)
            {}
            else if (!crawling && !lifting && !pushing)
            {
                canLift = true;
            } 
        }
        if(other.gameObject.tag == ("HideSpot") || other.gameObject.tag == ("HideSpot") && other.gameObject.tag != ("HideSpot"))
        {
            if(crawling || lifting || pushing)
            {}
            else if (!crawling && !lifting && !pushing){
                canHide = true;
            }
           
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == ("Ground"))
        {
            canStand = true;
        }
        if(other.gameObject.tag == ("HideSpot"))
        {
            canHide = false;
        }
        canLift = false;
    }
    public void BlockMovment()
    {
        canMove = false;
        PRB.isKinematic = true;
    }
    public void UnblockMovment()
    {
        canMove = true;
        PRB.isKinematic = false;
    }
}

