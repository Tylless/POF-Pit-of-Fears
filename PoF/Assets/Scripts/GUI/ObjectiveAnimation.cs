using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveAnimation : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dis()
    {
        this.gameObject.SetActive(false);
    }
    
    public void EndA()
    {
        anim.SetTrigger("Disappear");
    }
    
}
