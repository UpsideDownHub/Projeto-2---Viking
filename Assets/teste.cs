using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour {

    [SerializeField] SpriteRenderer playerSr;
    [SerializeField] Transform bottomTree;
    SpriteRenderer sr;

    void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {
        sr.sortingOrder = Mathf.RoundToInt(bottomTree.transform.position.y * -10f);
    }

    private void FixedUpdate()
    {

    }
}
