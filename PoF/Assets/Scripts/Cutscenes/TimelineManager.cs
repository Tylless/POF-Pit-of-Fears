using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class TimelineManager : MonoBehaviour
{
    public Animator PAnim;
    
    public PlayableDirector director;
    public RuntimeAnimatorController controller;
    public GameObject PS;
    public bool _fixed = false;
    public bool paused_ = false;
    public PlayerMovement PM;
    public Transform endingCSPoint;
    public CinemachineVirtualCamera cameraPosCS;
    

    // Start is called before the first frame update
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        PM = FindFirstObjectByType<PlayerMovement>();
        PM.BlockMovment();
    }

    void OnEnable()
    {
        controller = PAnim.runtimeAnimatorController;
        PAnim.runtimeAnimatorController = null;
        
    }
    // Update is called once per frame
    void Update()
    {
        
       if(paused_)
       {
        PM.PRB.isKinematic = true;
        PM.PRB.velocity = Vector2.zero;
        director.Pause();
        CursorManager.instance.CSPauseOn = true;

       }else
       {
        PM.PRB.isKinematic = false;
        PM.PRB.velocity = PM.PRB.velocity;
        director.Play();
        CursorManager.instance.CSPauseOn = false;
       }
        if(director.state == PlayState.Paused)
        {
            paused_ = true;
            PS.SetActive(true);
        }else
        {
            paused_ = false;
            PS.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused_)
            {
            paused_ = false;
            PS.SetActive(false);
            director.Play();
            
            }
            else
            {
            paused_ = true;
            PS.SetActive(true);
            
            director.Pause();
            
            }
        }
    }
      void FIX()
    {
        PAnim.runtimeAnimatorController = controller;
        _fixed = true;
        PM.transform.position = endingCSPoint.position;
        cameraPosCS.enabled = true;
        CameraManager.instance._currentCamera = cameraPosCS;
        PM.UnblockMovment();
        
        
    }
    void Destroy()
    {
        
        Destroy(this.gameObject);
    }
}
