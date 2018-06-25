using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geneticos{

    List<individuo> lista;
    int tam;

    public geneticos(int t)
    {
        tam = t;
        lista = new List<individuo>();
        float min = -10.0f;
        float max = 10.0f;
        for (int i = 0; i < t; i++)
        {
            float x1 = Random.Range(min, max);
            float x2 = Random.Range(min, max);
            float y1 = Random.Range(min, max);
            float y2 = Random.Range(min, max);
            float w1 = Random.Range(min, max);
            float w2 = Random.Range(min, max);
            lista.Add(new individuo(x1,x2,y1,y2,w1,w2));
        }    
    }

    public void evoluir()
    {
        Debug.Log("Evoluindo!");
        //faz nada por enquanto
    }

    public List<individuo> getLista()
    {
        return (lista);
    }


}
