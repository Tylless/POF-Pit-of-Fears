using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class FadeWall : MonoBehaviour
{
    public Tilemap wallSprite;
    public float fade;
    public float spriteO;
    public float full;
    public bool fading;
    public bool fulling;
    // Start is called before the first frame update
    void Start()
    {
        spriteO = 1;
        wallSprite.color = new Color(1, 1, 1, spriteO);
    }

    // Update is called once per frame
    void Update()
    {
        if(fading)
        {
            TurnFade();
        }
        if(fulling)
        {
            TurnFull();
        }
    }
    public void TurnFade()
    {
        if(spriteO > fade)
        {
            spriteO -= Time.deltaTime*5f;
            wallSprite.color = new Color(1, 1, 1, spriteO);
        }
        if(spriteO <= fade)
        {
            spriteO = fade;
            fading = false;
        }
    }
    public void TurnFull()
    {
        if(spriteO < full)
        {
            spriteO += Time.deltaTime*5f;
            wallSprite.color = new Color(1, 1, 1, spriteO);
            
        }
        if(spriteO >= full)
        {
            spriteO = full;
            fulling = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player")
        {
        fulling = false;
        fading = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player")
        {
        
       fulling = false;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        fulling = true;
        fading = false;
        }
        
    }
}
