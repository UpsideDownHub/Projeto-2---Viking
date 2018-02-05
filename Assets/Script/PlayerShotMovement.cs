using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Vector3 mouse;
    Vector3 direction;

    void Start()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = -1;
        direction = mouse - transform.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        Destroy(gameObject, 3);


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
        }

    }
}