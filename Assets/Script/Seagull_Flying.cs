using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull_Flying : MonoBehaviour {
    
    Vector3 v3 = new Vector3(0.25f, 0, 0);

    void Start () {
        Destroy(gameObject,5);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += v3;
    }
}
