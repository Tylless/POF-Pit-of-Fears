using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Ground") || collision.gameObject.tag == ("Pushable"))
        {
            PlayGroundAudio();
        }
    }
    public void PlayGroundAudio()
    {
        if(!PlayerMovement.instance.onGround && PlayerMovement.instance.canMove && PlayerMovement.instance.falling)
            {
                PlayerMovement.instance.PA.Fall();
            }
    }
}
