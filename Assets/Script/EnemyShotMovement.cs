using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotMovement : MonoBehaviour
{

    [SerializeField] float speed = 5;
    Vector3 PlayerPosition;
    [SerializeField] Transform Player;
    Vector3 direction;

    private void Start()
    {
        Player = GameObject.Find("Player").transform;

        PlayerPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, 0);

        direction = PlayerPosition - transform.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        Destroy(gameObject, 3);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }

    }
}
