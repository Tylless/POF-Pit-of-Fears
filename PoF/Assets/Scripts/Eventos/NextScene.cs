using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    public string sceneName;
    public GameObject loadScreen;
    public GameObject loadText;
    public float value;
    public static NextScene instance;

    // Update is called once per frame
    void Awake()
    {
      if (instance == null)
      {
        instance = this;
      }
    }
    public void CallLoading()
    {
        StartCoroutine(LoadNewScene(sceneName));
    }
    
    private IEnumerator LoadNewScene( string newScene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Single);
        while(!asyncOperation.isDone)
        {
            loadScreen.SetActive(true);
            value = (asyncOperation.progress * 100f);
            TextMeshProUGUI porcValue = loadText.GetComponent<TextMeshProUGUI>();
            porcValue.text = value + "%";
            
            
            yield return null;
        }
    }
}
