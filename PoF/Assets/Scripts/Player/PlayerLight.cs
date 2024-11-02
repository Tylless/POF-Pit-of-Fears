using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [Header("Components")]
    public static PlayerLight instance;
    public Light2D luz;
    [Header("Luz")]
    public float iluminação;
    // Start is called before the first frame update
    private void Awake()
    {
         if (instance == null)
        {
        instance = this;
        
        }}
    void Start()
    {
        luz.GetComponentInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
       UpLight();
    }
    public void UpLight()
    {
         if(luz.pointLightOuterRadius > iluminação)
        {
            luz.pointLightOuterRadius -= Time.deltaTime * 10;
        }
        if(luz.pointLightOuterRadius < iluminação)
        {
            luz.pointLightOuterRadius += Time.deltaTime * 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == ("LightHigh"))
        {
            iluminação = 10f;
        }
        if(other.gameObject.tag == ("LightMidHigh"))
        {
            iluminação = 7f;
        }
        if(other.gameObject.tag == ("LightMid"))
        {
            iluminação = 5f;
        }
        if(other.gameObject.tag == ("LightLow"))
        {
            iluminação = 1.3f;
        }
    }
}
