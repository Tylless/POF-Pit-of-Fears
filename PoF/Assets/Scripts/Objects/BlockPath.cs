using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPath : MonoBehaviour
{
    public GameObject pathBarrier;
    public AudioClip AU;
    public AudioSource a;

    // Start is called before the first frame update
    void Start()
    {
        pathBarrier.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(pathBarrier.activeSelf == false ) 
            {
            pathBarrier.SetActive(true);
            a.PlayOneShot(AU);
            }
           
        }
    }
}
