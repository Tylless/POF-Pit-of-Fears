using System.Collections;
using System.Collections.Generic;
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
    

    // Start is called before the first frame update
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        PM = FindFirstObjectByType<PlayerMovement>();
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
       }else
       {
        PM.PRB.isKinematic = false;
        PM.PRB.velocity = PM.PRB.velocity;
        director.Play();
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
        
        
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
