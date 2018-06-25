using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject template; // base 'nave' que ira ser feito copias
    private geneticos gen; // gera populacoes 

    bool start = false;

    // Use this for initialization
    void Start () {
        gen = new geneticos(5);
    }

    void spawn()
    {
        List<individuo> lista = gen.getLista();
        int len = lista.Count;
        int ySize = 17;
        int yStart = -6;
        for (int i = 0; i < len; i++)
        {
            GameObject clone = GameObject.Instantiate(template);
            clone.name = "clone_" + i;
            float posY = Random.Range(0.0f, ySize + 0.0f);
            clone.transform.position = new Vector3(-25, yStart + posY, 0);
            moveScript naveM = clone.GetComponent<moveScript>();
            naveM.active = true;
        }
    }

    IEnumerator manage()
    {
        Debug.Log("StartManage");
        yield return new WaitForSeconds(4);
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
        Debug.Log("Frame end");
    }
}
