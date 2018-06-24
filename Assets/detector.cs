using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour {
    public bool detectou = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisao entrou +1");   
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Colisao saiu -1");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
