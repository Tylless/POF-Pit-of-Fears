using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossSpawn : MonoBehaviour
{
    
    public GameObject BossToSpawn;
    public Transform spawnPoint;
    private void OnEnable() {
        GameObject Boss = Instantiate(BossToSpawn);
        Boss.transform.position = spawnPoint.position;
    }

    
    
    void Update() {
         if(RespawnController.instance.spawn == 1f)
        {
            this.gameObject.SetActive(false);
            
        }
    }
    
}
