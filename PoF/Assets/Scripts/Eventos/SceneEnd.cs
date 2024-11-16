using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnd : MonoBehaviour
{
    public string newScene;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            NextScene.instance.CallLoading(newScene);
        }
    }
}
