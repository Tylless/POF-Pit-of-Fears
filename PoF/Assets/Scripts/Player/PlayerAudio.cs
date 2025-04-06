using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    
    [SerializeField] private AudioSource passosAudioSource;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioClip[] passosAudioClip;
    [SerializeField] private AudioClip[] DieAudioClip;
    [SerializeField] private AudioClip FallAudioClip;
    [SerializeField] private AudioClip ResAudioClip;
    [SerializeField] private int passo;
    [SerializeField] private int passoEmpurra;
    [SerializeField] private AudioClip[] EmpurraAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        passo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Passos()
    {
        if(passo < (passosAudioClip.Length - 1))
        {
          passo = passo + 1;  
        }else if (passo >= (passosAudioClip.Length - 1))
        {
            passo = 0;
        }
        
        passosAudioSource.PlayOneShot(passosAudioClip[passo]);
    }
    public void Empurra()
    {
        if(passoEmpurra < (EmpurraAudioClip.Length - 1))
        {
          passoEmpurra = passoEmpurra + 1;  
        }else if (passoEmpurra >= (EmpurraAudioClip.Length - 1))
        {
            passoEmpurra = 0;
        }
        
        playerAudioSource.PlayOneShot(EmpurraAudioClip[passoEmpurra]);
    }
    public void Fall()
    {
        playerAudioSource.PlayOneShot(FallAudioClip);
    }
    public void DieAir()
    {
        playerAudioSource.PlayOneShot(DieAudioClip[1]);
    }
    public void DieGround()
    {
        playerAudioSource.PlayOneShot(DieAudioClip[0]);
    }
     public void DieSmash()
    {
        playerAudioSource.PlayOneShot(DieAudioClip[2]);
    }
    public void RespawnAudio()
    {
        playerAudioSource.PlayOneShot(ResAudioClip);
    }

    
}
