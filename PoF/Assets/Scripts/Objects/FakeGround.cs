using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGround : MonoBehaviour
{
    public static FakeGround instance;
    public Vector3 particleSpawn1;
    public Vector3 particleSpawn2;
    public Vector3 particleSpawn3;
    public Vector3 particleSpawn4;
    public Vector3 particleSpawn5;
    public Vector3 particleSpawn6;
    public Vector3 particleSpawn7;
    public Vector3 particleSpawn8;
    public Vector3 particleSpawn9;
    public Vector3 particleSpawn10;
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
    public void SpawnPar(Vector3 tp, float xSpeed)
    {
        
        GameObject par = Instantiate(particle, tp, Quaternion.identity);
        Vector2 fall = new Vector2(xSpeed, 4f);
        par.GetComponent<Rigidbody2D>().AddForce(fall, ForceMode2D.Impulse);
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            SpawnPar(particleSpawn1, 0.2f);
            SpawnPar(particleSpawn2, -0.3f);
            SpawnPar(particleSpawn3,-.35f);
            SpawnPar(particleSpawn4,.35f);
            SpawnPar(particleSpawn5,-.5f);
            SpawnPar(particleSpawn6,.5f);
            SpawnPar(particleSpawn7, -0.25f);
            SpawnPar(particleSpawn8,0.25f);
            SpawnPar(particleSpawn9, - 0.4f);
            SpawnPar(particleSpawn10, 0.4f);
            Destroy(this.gameObject);
        }
    }
}
