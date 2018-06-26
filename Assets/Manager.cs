using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject template; // base 'nave' que ira ser feito copias
    private geneticos gen; // gera populacoes 

    bool start = false;

    List<GameObject> spawnLista;
    private const int timeToRun = 5;

    public int tamanhoPop;
    // Use this for initialization
    void Start () {
        gen = new geneticos(tamanhoPop);
    }

    void despawn()
    {
        if (spawnLista != null)
        {
            for (int i = 0; i < spawnLista.Count; i++)
            {
                if (spawnLista[i] == null)
                {
                    Debug.Log("Ja foi removido");
                }
                else
                {
                    Debug.Log("Removendo " + spawnLista[i].name);
                    moveScript naveM = spawnLista[i].GetComponent<moveScript>();
                    naveM.v.fitness = spawnLista[i].transform.position.x + 1;
                    Destroy(spawnLista[i]);
                }
                
            }
        }
    }

    void spawn()
    {
        List<individuo> lista = gen.getLista();
        int len = lista.Count;
        int ySize = 15;
        int yStart = -5;
        if (spawnLista != null)
        {
            despawn();
        }
        spawnLista = new List<GameObject>();
        for (int i = 0; i < len; i++)
        {
            GameObject clone = GameObject.Instantiate(template);
            spawnLista.Add(clone);
            clone.name = "clone_" + i;
            float posY = Random.Range(0.0f, ySize + 0.0f);
            clone.transform.position = new Vector3(5, yStart + posY, 0);
            moveScript naveM = clone.GetComponent<moveScript>();
            naveM.setValues(lista[i]);
            naveM.active = true;
        }
    }

    IEnumerator manage()
    {
        Debug.Log("StartManage");
        for (int i = 0; i < 10; i++)
        {
            spawn();
            yield return new WaitForSeconds(timeToRun);
            despawn();
            gen.evoluir();
        }
        Debug.Log("FimMange");
    }

    void Update()
    {
        if (start == false)
        {
            start = true;
            StartCoroutine(manage());
            //start = false;
        }
        //Debug.Log("Frame end");
    }
}
