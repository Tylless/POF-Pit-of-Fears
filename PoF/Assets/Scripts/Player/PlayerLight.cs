using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    public Light2D PLight;
    public float ilumination;
    public float areaLight;
    void Update()
    {
        ilumination = areaLight * GameDificultLevel.instance.lightMultiplier;
        PLight.pointLightOuterRadius = ilumination;
    }
}
