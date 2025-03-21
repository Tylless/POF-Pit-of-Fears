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

    [Header("Scared")]
    public bool scared;

    [Header("Looking at")]
    public bool facingRight;
    public float facingDir;
    public float rotNum;

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
    
    [Header("Stuck")]
    public bool stuck;
    public float stuckNerf;

    [Header("PermaDeath")]
    public GameObject BSBHead;
    public GameObject BSBBody;
    
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
        }
            CheckGround();
            CanPush();
            Animation();
    }
   
    public void Death()
    {
        if(GameDificultLevel.instance.permaDeath)
        {
            PermaDie();
        }else
        {
            Die();
        }
    }
    
    public void Die()
    {
        
        if(onGround)
        {
            anim.SetTrigger("DieGround");
            
            PRB.velocity = Vector2.zero;
            
            BlockMovment();
        }else if(!onGround)
        {
            
            BlockMovment();
            falling = false;
            jumping = false;
            PRB.velocity = Vector2.zero;
            anim.SetTrigger("DieAir");
        }    
    
    }
    
    public void PermaDie()
    {
        
        if(onGround)
        {
            anim.SetTrigger("PermaDeathGround");
            
            PRB.velocity = Vector2.zero;
            
            BlockMovment();
        }else if(!onGround)
        {
            
            BlockMovment();
            falling = false;
            jumping = false;
            PRB.velocity = Vector2.zero;
            anim.SetTrigger("PermaDeathAir");
        }    
    
    }
    public void ShowDeathScreen()
    {
        NextScene.instance.CallLoading("PermaDeath");
    }
    public void SpawnBody()
    {
        GameObject body = Instantiate(BSBBody);
        GameObject head = Instantiate(BSBHead);
        body.transform.position = liftPoint.transform.position;
        head.transform.position = new Vector3(liftPoint.transform.position.x, liftPoint.transform.position.y + 1f, liftPoint.transform.position.z);
    }
    
        
    

    public void BeSmashed()
    {
        if(onGround)
        {
        if(GameDificultLevel.instance.permaDeath)
        {
            BlockMovment();
            PRB.velocity = Vector2.zero;
            anim.SetTrigger("PermaDeathSmash");
        }else
        {
            
            anim.SetTrigger("DieSmash");
            this.transform.localScale = new Vector2(transform.localScale.x, 0.5f);
            BlockMovment();
            PRB.velocity = Vector2.zero;
        }
        }
        if(!onGround)
        {
            if(GameDificultLevel.instance.permaDeath)
        {
           ShowDeathScreen();
        }else
        {
            BlockMovment();
            Respawn();
        }
        }
            
    }
    public void Respawn()
    {
        RespawnController.instance.Respawn();
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        facingRight = !facingRight;
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
           facingRight = !facingRight;
           facingDir = -1f;
           CM.CallTurn();
           transform.localScale = new Vector2(-0.5f , transform.localScale.y);
        }else
        {
           facingRight = !facingRight;
           facingDir = 1f;
           CM.CallTurn();
           transform.localScale = new Vector2(0.5f , transform.localScale.y);
        }
    }
    
    public void Animation()
    {
        int standHash = Animator.StringToHash("Standing?");
        int crawlHash = Animator.StringToHash("Crawling?");
        int liftHash = Animator.StringToHash("Lifting?");
        int walkHash = Animator.StringToHash("Moving?");
        int runHash = Animator.StringToHash("Running?");
        int jumpHash = Animator.StringToHash("Jumping?");
        int fallHash = Animator.StringToHash("Falling?");
        int pushHash = Animator.StringToHash("Pushing?");
        int hideHash = Animator.StringToHash("Hiding?");
        int scaryHash = Animator.StringToHash("Scared");


        if(standing)
        {
            anim.SetBool(standHash, true);
            anim.SetBool(crawlHash, false);
            anim.SetBool(liftHash, false);
        }
        if(crawling)
        {
            anim.SetBool(standHash, false);
            anim.SetBool(crawlHash, true);
            anim.SetBool(liftHash, false);
        }
        if(lifting)
        {
            anim.SetBool(standHash, false);
            anim.SetBool(crawlHash, false);
            anim.SetBool(liftHash, true);
        }
        if(walking)
        {
            anim.SetBool(walkHash, true);
            anim.SetBool(runHash, false);
        }else
        {
            anim.SetBool(walkHash, false);
        }
        if(running)
        {
            anim.SetBool(walkHash, true);
            anim.SetBool(runHash, true);
        }else
        {
            anim.SetBool(runHash, false);
        }
        if(jumping)
        {
            anim.SetBool(jumpHash, true);
        }else
        {
            anim.SetBool(jumpHash, false);
        }
        if(falling)
        {
            anim.SetBool(fallHash, true);
        }else
        {
            anim.SetBool(fallHash, false);
        }
        if(pushing)
        {
            anim.SetBool(pushHash, true);
        }else
        {
            anim.SetBool(pushHash, false);
        }
        if(hiding)
        {
            anim.SetBool(hideHash, true);
        }else
        {
            anim.SetBool(hideHash, false);
        }
        if(scared)
        {
            anim.SetBool(scaryHash, true);
            anim.SetBool(standHash, false);
        }else
        {
            anim.SetBool(scaryHash, false);
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
        if(stuck)
        {
            moveSpeed = walkSpeed * stuckNerf;
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
   public void Scared()
   {
    scared = true;
    canMove = false;
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
            falling = false;
            jumping = false;
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
        if(PRB.velocity.y > 0 && !onGround)
        {
            jumping = true;
            falling = false;

        }
        if(PRB.velocity.y < 0 && !onGround)
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
        if(Input.GetKeyDown(KeyCode.W))
        {
        if(canHide)
        {
        if(!hiding)
        {
            hiding = true;
        }else{
        
            hiding = false;
        }
        }
        }
        if(hiding)
        {
            canCrawl = false;
            canJump = false;
            canLift = false;
            canPush = false;
            canThrow = false;
            SR.sortingOrder = 8;
        }
        if(!hiding)
        {
            SR.sortingOrder =11;
        }
        if(jumping || falling || lifting  || pushing || crawling)
        {
            canHide = false;
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
        if(other.gameObject.tag == ("EnterHide") || other.gameObject.tag == ("EnterHide") && other.gameObject.tag != ("EnterHide"))
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
        if(other.gameObject.tag == ("EnterHide") || other.gameObject.tag == ("EnterHide") && other.gameObject.tag != ("EnterHide"))
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
        if(other.gameObject.tag == ("EnterHide"))
        {
            canHide = false;
        }
        if(other.gameObject.tag == ("HideSpot"))
        {
            hiding = false;
        }
        canLift = false;
    }
    public void BlockMovment()
    {
        canMove = false;
        PRB.isKinematic = true;
        PRB.velocity = Vector2.zero;
    }
    public void UnblockMovment()
    {
        canMove = true;
        PRB.isKinematic = false;
    }
}

