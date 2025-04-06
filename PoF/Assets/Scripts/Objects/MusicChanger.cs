using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    private Collider2D _coll;
    public int musicIdRight;
     public int musicIdLeft;
    // Start is called before the first frame update
    void Start()
    {
        _coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            Vector2 exitDirection = (coll.transform.position - _coll.bounds.center).normalized;

            if(exitDirection.x > 0)
            {
                AudioController.instance.MudarTrilha(musicIdRight);
            }
             if(exitDirection.x < 0)
            {
                AudioController.instance.MudarTrilha(musicIdLeft);
            }
        }
    }

}


