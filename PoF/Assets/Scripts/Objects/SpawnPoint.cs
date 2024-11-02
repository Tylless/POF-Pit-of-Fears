using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public CinemachineVirtualCamera RC;
    public float luz;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RespawnController.instance.SetSpawn(transform.position);
             RespawnController.instance.luzResp = luz;
            RespawnController.instance.respawnCamera = RC;
        }
    }
}
