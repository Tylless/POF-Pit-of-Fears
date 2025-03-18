using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public static PushableObject instance;
    public PlayerMovement PM;
    public Rigidbody2D TRB;
    public SpriteRenderer SR;
    public bool beingPushed;
    public float pushingMass;
    public bool pushingByObject;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PM = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(beingPushed && PM.pushing)
        {
            TRB.mass = pushingMass;
            SR.sortingOrder = 10;
        }
        if(!PM.pushing && beingPushed)
        {
            TRB.mass = 800f;
            TRB.velocity = new Vector2(0f, TRB.velocity.y);
            SR.sortingOrder = 13;
        }
        if(pushingByObject)
        {
            TRB.mass = pushingMass;
            SR.sortingOrder = 10;
        }
        if(!pushingByObject && !PM.pushing)
        {
            TRB.velocity = new Vector2(0f, TRB.velocity.y);
            TRB.mass = 800f;
            SR.sortingOrder = 10;
        }
        if(PM.lifting)
        {
            TRB.isKinematic = true;
        }else
        {
            TRB.isKinematic = false;
        }
        if(RespawnController.instance.spawn == 1f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            beingPushed = true;
        }
        if(other.gameObject.tag =="Pushable")
        {
            pushingByObject = true;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            beingPushed = true;
        }
        if(other.gameObject.tag =="Pushable")
        {
            pushingByObject = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        
            if(other.gameObject.tag =="Player")
        {
            beingPushed = false;
        }
        if(other.gameObject.tag =="Pushable")
        {
            pushingByObject = false;
        }
        
    }
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
