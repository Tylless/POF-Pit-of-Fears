using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource trilhaSonora;
    public AudioSource SFX;
    
    public AudioClip[] trilhasSonoras;
    private AudioClip trilhaSonoraAtual;
    
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
        trilhaSonoraAtual = trilhasSonoras[0];
        trilhaSonora.clip = trilhaSonoraAtual;
        trilhaSonora.loop = true;
        trilhaSonora.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MudarTrilha(int numeroTrilha)
    {
        if(trilhasSonoras[numeroTrilha] != trilhaSonoraAtual)
        {trilhaSonoraAtual = trilhasSonoras[numeroTrilha];
        trilhaSonora.clip = trilhaSonoraAtual;
        trilhaSonora.loop = true;
        trilhaSonora.Play();}
        
    }
    public void TocarSFX(AudioClip sfx)
    {   
        SFX.PlayOneShot(sfx);
    }
    
}
