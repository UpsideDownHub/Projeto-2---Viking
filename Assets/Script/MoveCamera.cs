using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    [SerializeField] GameObject player;
    
    private Vector3 offset;         
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && Camera.main.orthographicSize > 5 ) // forward
        {
            Camera.main.orthographicSize--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && Camera.main.orthographicSize < 9 ) // backwards
        {
            Camera.main.orthographicSize++;
        }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
