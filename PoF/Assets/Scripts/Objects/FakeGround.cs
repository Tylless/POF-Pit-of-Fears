using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGround : MonoBehaviour
{
    public static FakeGround instance;
    public Transform particleSpawn;
    public GameObject particle;

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
    public void Break()
    {
        
        Instantiate(particle, particleSpawn.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            Break();
        }
    }
}
