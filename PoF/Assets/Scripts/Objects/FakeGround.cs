using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGround : MonoBehaviour
{
    public static FakeGround instance;
    public Transform[] particleSpawn;
    public GameObject particle;
    public GameObject breakEffect;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPar(Vector3 tp, float xSpeed)
    {
        
        GameObject par = Instantiate(particle, tp, Quaternion.identity);
        Vector2 fall = new Vector2(xSpeed, 4f);
        par.GetComponent<Rigidbody2D>().AddForce(fall, ForceMode2D.Impulse);
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            GameObject audioef = Instantiate(breakEffect, new Vector3(this.transform.position.x, this.transform.position.y, 
            this.transform.position.z), Quaternion.identity);
            this.gameObject.SetActive(false);
            foreach(Transform t in particleSpawn)
            {
                SpawnPar(t.position, .4f);
            }
            
            
        }
    }
}
