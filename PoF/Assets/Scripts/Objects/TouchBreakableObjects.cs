using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBreakableObjects : MonoBehaviour
{
    public GameObject FullWeb;
    public GameObject BrokeWeb;
    // Start is called before the first frame update
    void Start()
    {
        FullWeb.SetActive(true);
        BrokeWeb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            FullWeb.SetActive(false);
            BrokeWeb.SetActive(true);
        }
        
    }


}
