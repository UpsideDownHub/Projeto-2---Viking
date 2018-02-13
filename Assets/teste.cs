using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour {

    [SerializeField] SpriteRenderer playerSr;
    SpriteRenderer sr;
    BoxCollider2D collider1;
    BoxCollider2D collider2;

    void Start () {
        collider1 = GetComponents<BoxCollider2D>()[0];
        collider2 = GetComponents<BoxCollider2D>()[1];
        sr = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {
        sr.sortingOrder = Mathf.RoundToInt(transform.position.y * -10f);
    }

    private void FixedUpdate()
    {
        if(playerSr.sortingOrder > sr.sortingOrder)
        {
            collider1.isTrigger = false;
            collider2.isTrigger = true;
        }
        else
        {
            collider1.isTrigger = true;
            collider2.isTrigger = false;
        }
    }
}
