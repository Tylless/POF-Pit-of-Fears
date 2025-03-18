using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseManager : MonoBehaviour
{
    public GameObject[] chaseGameObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RespawnController.instance.spawn == 1f)
        {
            foreach(GameObject go in chaseGameObjects)
            {
                go.SetActive(true);
            }
        }
    }
}
