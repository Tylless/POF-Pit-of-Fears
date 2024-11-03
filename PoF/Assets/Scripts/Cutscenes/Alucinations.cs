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
        
        PlayerMovement.instance.PRB.velocity = Vector2.zero;
        StartCoroutine(ShowAlu());
        
    }
    public IEnumerator ShowAlu()
    {
        PlayerMovement.instance.BlockMovment();
        PlayerMovement.instance.anim.SetTrigger("Scared");
        PlayerLight.instance.iluminação = 1.3f;
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
        PlayerLight.instance.iluminação = 7f;
        
        
        yield return null;
        
        Destroy(this.gameObject);
        
       
        PlayerMovement.instance.UnblockMovment();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            Alu();
        }
    }
    
}
