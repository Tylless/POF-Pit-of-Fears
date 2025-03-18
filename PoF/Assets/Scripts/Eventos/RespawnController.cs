using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public static RespawnController instance;
    private Vector3 respawnPoint;
    public float waitToRespawn;
    public GameObject DS;
    private GameObject thePlayer;
   
    public float spawn;
    public CinemachineVirtualCamera respawnCamera;
    // Start is called before the first frame update
    private void Awake()
    {
         if (instance == null)
        {
        instance = this;
        
        }}
    void Start()
    {
        thePlayer = PlayerMovement.instance.gameObject;
        
    }
    void Update()
    {
        
            
        
    }
    public void SetSpawn(Vector3 newPosition)
    {
        respawnPoint = newPosition;
        
    }
    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    
    }
     IEnumerator RespawnCo()
    {
        
        DS.SetActive(true);
        PlayerMovement.instance.canMove = false;
        CameraManager.instance._currentCamera.enabled = false; 
        spawn = 1;
        yield return new WaitForSeconds(.1f);
        spawn = 0.9f;
        yield return new WaitForSeconds(.1f);
        spawn = 0f;
        CameraManager.instance._currentCamera = respawnCamera;
        thePlayer.transform.position = respawnPoint;
        
        CameraManager.instance._currentCamera.enabled = true; 
        yield return new WaitForSeconds(waitToRespawn);
        
        
        PlayerMovement.instance.anim.SetTrigger("WakeUpResp");
        PlayerMovement.instance.lifting = false;
        PlayerMovement.instance.crawling = false;
        PlayerMovement.instance.hiding = false;
        PlayerMovement.instance.pushing = false;
        PlayerMovement.instance.falling = false;
        PlayerMovement.instance.jumping = false;
        PlayerMovement.instance.BlockMovment();
        PlayerMovement.instance.PRB.velocity = Vector2.zero;
        DS.SetActive(false);      
        
        yield return null;
    }
    
    
}
