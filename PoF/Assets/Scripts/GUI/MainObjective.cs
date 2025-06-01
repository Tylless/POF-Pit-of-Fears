using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainObjective : MonoBehaviour
{
    public string[] objetivos, objectives;
    public bool PTBR, ENG;
    public int linguagem;
    public TMP_Text objetivoAtualMenu;
    public TMP_Text objetivoAtualGame;
    public GameObject objetivoDisplay;
    public static MainObjective instance;
    public GameObject objetivoVisivel;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public int numeroObjetivo;    // Start is called before the first frame update
    void Start()
    {
        linguagem = PlayerPrefs.GetInt("Language");
        if(linguagem == 0)
        {
            ENG = true;
            PTBR = false;
        }else if (linguagem == 1)
        {
            ENG = false;
            PTBR = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NovoObjetivo(int novoNúmero)
    {
        numeroObjetivo = novoNúmero;
        MudarTexto();
        objetivoVisivel.SetActive(true);
    }
    public void MudarTexto()
    {
        if(PTBR)
        {
            objetivoAtualMenu.text = objetivos[numeroObjetivo];
            objetivoAtualGame.text = objetivos[numeroObjetivo];
        }else if(ENG)
        {
            objetivoAtualMenu.text = objectives[numeroObjetivo];
            objetivoAtualGame.text = objectives[numeroObjetivo];
        }
        
    }
    public void AdicionarObjetivo()
    {
        numeroObjetivo = 0;
        MudarTexto();
        objetivoDisplay.SetActive(true);
        objetivoVisivel.SetActive(true);
        
    }
}
