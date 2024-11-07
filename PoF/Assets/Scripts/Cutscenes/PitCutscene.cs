using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitCutscene : MonoBehaviour
{
    public Pit pit;
    public bool canActivate;
    public Transform enterPoint;
    void Update()
    {
        if(canActivate)
        {
        if (Input.GetKeyDown(KeyCode.E)){
            pit.explode = true;
            PlayerMovement.instance.anim.SetTrigger("Explode");
            
            PlayerMovement.instance.BlockMovment();
            PlayerMovement.instance.PRB.velocity = Vector2.zero;
            PlayerMovement.instance.transform.position = new Vector3(enterPoint.position.x,  PlayerMovement.instance.transform.position.y,  PlayerMovement.instance.transform.position.z);
            
           
        }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerTuto")
    {
        canActivate = true;
    }
    
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerTuto")
    {
        canActivate = false;
    }
    
    }
    

}
