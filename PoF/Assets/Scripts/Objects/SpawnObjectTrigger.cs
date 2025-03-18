using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObjectTrigger : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Collider2D col;
    public GameObject ChaseBarrier;
    // Start is called before the first frame update
    void Update() {
         if(RespawnController.instance.spawn == 1f)
        {
            col.enabled = true;
            ChaseBarrier.SetActive(true);
        }
    }
    void Spawn()
    {
        
        objectToSpawn.SetActive(true);
        col.enabled = false;
        ChaseBarrier.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Spawn();
        }
    }
}
