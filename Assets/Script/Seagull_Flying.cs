using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull_Flying : MonoBehaviour {

    Vector3 move_Right = new Vector3(0.25f, 0, 0);

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    void FixedUpdate () {
        transform.position += move_Right;
    }
}
