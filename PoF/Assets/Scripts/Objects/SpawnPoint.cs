using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public CinemachineVirtualCamera RC;
    public int spawnST;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RespawnController.instance.SetSpawn(transform.position);
            RespawnController.instance.respawnCamera = RC;
            RespawnController.instance.valorTrilha = spawnST;
        }
    }
}
