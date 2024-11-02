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
    public Transform spawn;
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
        if(!PM.pushing)
        {
            TRB.mass = 800f;
            TRB.velocity = new Vector2(0f, TRB.velocity.y);
            SR.sortingOrder = 13;
        }
        if(!beingPushed)
        {
            TRB.mass = 800f;
            SR.sortingOrder = 13;
        }
        if(PM.lifting)
        {
            TRB.isKinematic = true;
        }else
        {
            TRB.isKinematic = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            beingPushed = true;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            beingPushed = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        
            beingPushed = false;
        
    }
    public void GoToSpawn()
    {
     transform.position = spawn.position;
     this.gameObject.SetActive(true);
    }
}
