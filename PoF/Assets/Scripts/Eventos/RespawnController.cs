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
    public int valorTrilha;
    public int objt;
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
        thePlayer.transform.position = respawnPoint;
        PlayerMovement.instance.canMove = false;
        CameraManager.instance._currentCamera.enabled = false; 
        spawn = 1;
        yield return new WaitForSeconds(.1f);
        spawn = 0.9f;
        yield return new WaitForSeconds(.1f);
        spawn = 0f;
        if(MainObjective.instance.PTBR)
        {
            MainObjective.instance.objetivoAtualMenu.text =  MainObjective.instance.objetivos[objt];
        }else if (MainObjective.instance.ENG)
        {
            MainObjective.instance.objetivoAtualMenu.text =  MainObjective.instance.objectives[objt];
        }
        
        CameraManager.instance._currentCamera = respawnCamera;
        
        
        CameraManager.instance._currentCamera.enabled = true;
        AudioController.instance.trilhaSonora.volume = 0f;

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
        AudioController.instance.trilhaSonora.volume = 1f;
        AudioController.instance.MudarTrilha(valorTrilha);
        DS.SetActive(false);      
        
        yield return null;
    }
    
    
}
