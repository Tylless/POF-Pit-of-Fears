using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alucinations : MonoBehaviour
{
    public GameObject frame;
    public GameObject image1;
    public GameObject image2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Alu()
    {
        
        StartCoroutine(ShowAlu());
        
    }
    public void PlayAnim()
    {
    PlayerMovement.instance.Scared();
    }
    public IEnumerator ShowAlu()
    {
        PlayerMovement.instance.PRB.velocity = Vector2.zero;
        yield return new WaitUntil(()  => PlayerMovement.instance.onGround == true);
        PlayAnim();
        PlayerMovement.instance.PRB.velocity = Vector2.zero;
        
        frame.SetActive(true);
        image1.SetActive(true);
        yield return new WaitForSeconds(1f);
        image1.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        image2.SetActive(true);
        yield return new WaitForSeconds(1f);
        image2.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        image1.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        image1.SetActive(false);
        image2.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        image2.SetActive(false);
        image1.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        image2.SetActive(false);
        image1.SetActive(false);
        frame.SetActive(false);
        
        
        
        yield return null;
        
        Destroy(this.gameObject);
        PlayerMovement.instance.scared = false;
        PlayerMovement.instance.UnblockMovment();
        
    }

    private Func<bool> System(bool onGround)
    {
        throw new NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            Alu();
        }
    }
    
}
