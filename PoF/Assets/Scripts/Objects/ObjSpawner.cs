using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public GameObject Object;
    [SerializeField]
    private GameObject Instanced;
    private void Start()
    {
        Respawn();
    }
    private void Update()
    {
        if(RespawnController.instance.spawn == 0.9f)
        {
            Respawn();
        }
    }
    public void Respawn()
    {
        if(Instanced == null)
        {
            Instanced = Instantiate(Object, this.transform.position, this.transform.rotation);
        }
        
    }
    
    
}
