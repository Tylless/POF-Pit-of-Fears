using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLO : MonoBehaviour
{
    public GameObject O;
    public GameObject NS;
    public Transform spawn;
    public static SpawnLO instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        SpawnO();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnO()
    {
        
        if(NS != null)
        {
            Destroy(NS);
            NS = Instantiate(O);
            NS.transform.position = spawn.position;
        }else if(NS == null)
        {
            NS = Instantiate(O);
            NS.transform.position = spawn.position;
        }
        
    }
    
}
