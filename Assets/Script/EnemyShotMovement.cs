using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotMovement : MonoBehaviour {

    [SerializeField] float speed = 5;
    Vector3 PlayerPosition;
    [SerializeField] Transform Player;

    private void Start()
    {
        Player = GameObject.Find("Player").transform;
        PlayerPosition = new Vector3(Player.transform.position.x, Player.transform.position.y,0);
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerPosition, speed * Time.deltaTime);

        if (transform.position == PlayerPosition)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 5);
        }


    }
}
