using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeping : MonoBehaviour
{
    public Animator anim;
    public AudioSource AuS;
    public AudioClip[] Sleep;
    public int au;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Sleeping", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySleepingAudio()
    {
        if(au < (Sleep.Length - 1))
        {
          au = au + 1;  
        }else if (au >= (Sleep.Length - 1))
        {
            au = 0;
        }
        
        AuS.PlayOneShot(Sleep[au]);
    }
}
