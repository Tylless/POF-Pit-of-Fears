using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckWeb : MonoBehaviour
{
    public float nerf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement.instance.stuckNerf = nerf;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            PlayerMovement.instance.stuck = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            PlayerMovement.instance.stuck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            PlayerMovement.instance.stuck = false;
        }
    }
}
