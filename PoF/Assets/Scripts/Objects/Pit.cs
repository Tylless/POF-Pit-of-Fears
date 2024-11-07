using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    public Animator anim;
    public bool explode;
    public NextScene NS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(explode)
        {
            
            anim.SetTrigger("Explode");
            
        }
    }
    public void CallScene()
    {
        NS.CallLoading();
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            anim.SetTrigger("Open");
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            anim.SetTrigger("Close");
        }
    }
}
