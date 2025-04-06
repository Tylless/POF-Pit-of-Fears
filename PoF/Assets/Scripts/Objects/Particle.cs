using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject destroyEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground")
        {
            GameObject audioef = Instantiate(destroyEffect, new Vector3(this.transform.position.x, this.transform.position.y, 
            this.transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
