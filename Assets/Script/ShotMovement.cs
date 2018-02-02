using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour {

    [SerializeField] float speed = 5;
    Vector3 mouse;

	void Start () {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = -1;
	}
	
	void FixedUpdate () {
        int T;

        transform.position = Vector3.MoveTowards(transform.position, mouse, speed * Time.deltaTime);

        if(transform.position == mouse)
        {
            T = 0;
        }
        else
        {
            T = 5;
        }

        Destroy(gameObject, T);

    }
}
