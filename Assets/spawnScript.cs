using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour {
    public GameObject template;

	// Use this for initialization
	void Start () {
        GameObject clone = Object.Instantiate(template);
        Transform tf = clone.transform;
        tf.position = new Vector3(-9,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
