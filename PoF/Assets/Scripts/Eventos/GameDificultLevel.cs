using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDificultLevel : MonoBehaviour
{
    public static GameDificultLevel instance;
    [Header("GameChanges")]
    public float speedMultiplier;
    public float lightMultiplier;
    public float stunMultiplier;
    public bool permaDeath;
    [Header("DificultLevels")]
    public bool WhisperOfFearDiff;
    public bool EchoesOfDreadDiff;
    public bool LivingNightmareDiff;
    public bool AbsoluteHorrorDiff;
    
    
    private void OnEnable() {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Awake() {
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
        if(WhisperOfFearDiff)
        {
            speedMultiplier = .6f;
            stunMultiplier = 1.4f;    
            lightMultiplier = 1.25f;
            permaDeath = false;
            EchoesOfDreadDiff = false;
            LivingNightmareDiff = false;
            AbsoluteHorrorDiff = false;
        }
        if(EchoesOfDreadDiff)
        {
            speedMultiplier = 1f;
            stunMultiplier = 1f; 
            lightMultiplier = 1f;
            permaDeath = false;
            WhisperOfFearDiff = false;
            LivingNightmareDiff = false;
            AbsoluteHorrorDiff = false;
        }
        if(LivingNightmareDiff)
        {
            speedMultiplier = 1.2f;
            stunMultiplier = .9f; 
            lightMultiplier = 0.95f;
            permaDeath = false;
            EchoesOfDreadDiff = false;
            WhisperOfFearDiff = false;
            AbsoluteHorrorDiff = false;
        }
        if(AbsoluteHorrorDiff)
        {
            speedMultiplier = 1.5f;
            stunMultiplier = .75f; 
            lightMultiplier = .8f;
            permaDeath = true;
            EchoesOfDreadDiff = false;
            WhisperOfFearDiff = false;
            LivingNightmareDiff = false;
        }

    }
}
