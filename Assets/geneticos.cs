using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geneticos{

    List<individuo> lista;

    float taxaDeCruzamento = 0.8f; // entre 0-1
    float taxaDeMutacao = 0.01f; // entre 0-1

    private individuo best = null;

    public geneticos(int t)
    {
        Debug.Log("t : " + t);
        lista = new List<individuo>();
        float min = -10.0f;
        float max = 10.0f;
        for (int i = 0; i < t; i++)
        {
            float x1 = Random.Range(min, max);
            float x2 = Random.Range(min, max);
            float x3 = Random.Range(min, max);
            float y1 = Random.Range(min, max);
            float y2 = Random.Range(min, max);
            float y3 = Random.Range(min, max);
            float w1 = Random.Range(min, max);
            float w2 = Random.Range(min, max);
            float w3 = Random.Range(min, max);
            lista.Add(new individuo(x1,x2,x3,y1,y2,y3,w1,w2,w3));
        }
        Debug.Log("gen size : " + t + "=" + lista.Count);
    }

    private void saveElite()
    {
        lista.Sort();
        individuo maior = lista[lista.Count - 1];
        string s = "Maior : " + lista[lista.Count - 1].ToString() + "\n" +
        "Menor : " + lista[0].ToString() + "\n";
        if (best == null)
        {
            s = s + "BestSoFar: null";
        }
        else
        {
            s = s + "BestSoFar : " + best.ToString(); 
        }
        s = s + "\n";
        Debug.Log(s);
        if (best==null || maior.fitness > best.fitness)
        {
            best = maior;
        }
    }

    private void loadElite(List<individuo> tmp)
    {
        tmp.Sort();
        tmp[0] = new individuo(best);
    }

    private List<individuo> selecao()
    {
        int tam = lista.Count;
        List<individuo> tmpLista = new List<individuo>();
        float totalFitness = 0f;
        for (int i = 0; i < lista.Count; i++)
        {
            individuo tmp = lista[i];
            totalFitness += tmp.fitness;
        }
        //Debug.Log("total fitness : " + totalFitness);
        for (int i = 0; i < tam; i++)
        {
            float rand = Random.Range(0.0f, totalFitness);
            float acumulado = 0f;
            int indexSelecionado = 0;
            for (int j = 0; j < tam; j++)
            {
                acumulado += lista[i].fitness;
                if (acumulado >= rand)
                {
                    indexSelecionado = j;
                    break;
                }
            }
            //Debug.Log("Selecionou index " + indexSelecionado);
            tmpLista.Add(lista[indexSelecionado]);
        }
        return (tmpLista);
    }

    private List<individuo> cruzamento(List<individuo> tmp)
    {
        int tam = tmp.Count;
        int count = 0;
        List<individuo> ret = new List<individuo>();
        while (count != tam)
        {
            int id1 = Mathf.RoundToInt(Random.Range(0f,tam-1f)); // sorteia de 0 - tam-1
            int id2 = Mathf.RoundToInt(Random.Range(0f, tam - 1f));
            while (id1 == id2)
            {
                id2 = Mathf.RoundToInt(Random.Range(0f, tam - 1f));
            }
            float temCruzamento = Random.Range(0f, 1f);
            individuo novo1;
            individuo novo2;
            if (temCruzamento <= taxaDeCruzamento)
            {
                float percentage = 0.7f;
                float contraPercentage = 1f - percentage;
                //Debug.Log("id1 : " + id1 + "x1 : " + lista[id1].x1);
                //Debug.Log("id2 : " + id2 + "x1 : " + lista[id2].x1);
                novo1 = new individuo(lista[id1], lista[id2], percentage);
                novo2 = new individuo(lista[id1], lista[id2], contraPercentage);
                //Debug.Log(novo1.ToString());
                //Debug.Log(novo2.ToString());
            }
            else
            {
                novo1 = new individuo(lista[id1]);
                novo2 = new individuo(lista[id2]);
            }
            ret.Add(novo1);
            ret.Add(novo2);
            count += 2;
        }
        return (ret);
    }

    public void mutacao(List<individuo> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            individuo ind = lista[i];
            float temMutacao = Random.Range(0f, 1f);
            if (temMutacao <= taxaDeMutacao)
            {
                ind.x1 += Random.Range(-1f, 1f) * 10;
            }
            temMutacao = Random.Range(0f, 1f);
            if (temMutacao <= taxaDeMutacao)
            {
                ind.x2 += Random.Range(-1f, 1f) * 10;
            }
            temMutacao = Random.Range(0f, 1f);
            if (temMutacao <= taxaDeMutacao)
            {
                ind.x3 += Random.Range(-1f, 1f) * 10;
            }
            temMutacao = Random.Range(0f, 1f);
            if (temMutacao <= taxaDeMutacao)
            {
                ind.y1 += Random.Range(-1f, 1f) * 10;
            }
            temMutacao = Random.Range(0f, 1f);
            if (temMutacao <= taxaDeMutacao)
            {
                ind.y2 += Random.Range(-1f, 1f) * 10;
            }
            temMutacao = Random.Range(0f, 1f);
            if (temMutacao <= taxaDeMutacao)
            {
                ind.y3 += Random.Range(-1f, 1f) * 10;
            }
            temMutacao = Random.Range(0f, 1f);
            if (temMutacao <= taxaDeMutacao)
            {
                ind.w1 += Random.Range(-1f, 1f) * 10;
            }
            temMutacao = Random.Range(0f, 1f);
            if (temMutacao <= taxaDeMutacao)
            {
                ind.w2 += Random.Range(-1f, 1f) * 10;
            }
            temMutacao = Random.Range(0f, 1f);
            if (temMutacao <= taxaDeMutacao)
            {
                ind.w3 += Random.Range(-1f, 1f) * 10;
            }
        }
    }

    public void evoluir()
    {
        //Debug.Log("Evoluindo!");
        Debug.Log("Entrada : " + this.ToString());
        //guarda melhor local se for melhor que melhor global
        saveElite();

        //selecao
        List<individuo> tmp = selecao();

        // cruzamento
        tmp = cruzamento(tmp);

        //mutacao
        mutacao(tmp);

        //substitui pior local por melhor global
        //loadElite(tmp);
        
        lista = tmp;
        //Debug.Log("fim evolucao!");
        //Debug.Log("Saida : " + this.ToString());
    }

    public List<individuo> getLista()
    {
        return (lista);
    }

    override
    public string ToString()
    {
        string ret = "";
        for (int i = 0; i < lista.Count; i++)
        {
            individuo indi = lista[i];
            ret = ret + indi.ToString() + "\n";
        }
        return (ret);
    }


}
