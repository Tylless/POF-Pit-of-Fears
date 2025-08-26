using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossWall : MonoBehaviour
{
    public GameObject particle;
    public Transform[] particleSpawn;
    public GameObject BOSSAudio;
    public GameObject WALLAudio;
    
    public float particleSide;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Kill")
        {
            
            
            Break();
            
        }
    }
    public void Break()
    {   GameObject audio1 = Instantiate(BOSSAudio, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        GameObject audio2 = Instantiate(WALLAudio, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        this.gameObject.SetActive(false);
        foreach(Transform t in particleSpawn)
            {
                
                SpawnPar(t.position);
            }
    }
    public void SpawnPar(Vector3 tp)
    {
        
        GameObject par = Instantiate(particle, tp, Quaternion.identity);
        Vector2 fall = new Vector2(particleSide*8f, 4f);
        par.GetComponent<Rigidbody2D>().AddForce(fall, ForceMode2D.Impulse);
        
    }

}
