using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjective : MonoBehaviour
{
    public Collider2D col;
    public bool startObjective, otherObjective;
    public int objective;
    public bool reaparecer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RespawnController.instance.spawn == 1f)
        {
            if(reaparecer)
            {
                col.enabled = true;
            }
            
        }
    }
    public void adicionarOBJ()
    {
        if(startObjective)
        {
            MainObjective.instance.AdicionarObjetivo();
        }else if(otherObjective)
        {
            MostrarNovoObjetivo(objective);
        }
    }
    public void MostrarNovoObjetivo(int novoO)
    {
        MainObjective.instance.NovoObjetivo(novoO);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            adicionarOBJ();
            col.enabled = false;
        }
    }
}
