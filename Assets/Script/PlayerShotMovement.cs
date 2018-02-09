using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotMovement : MonoBehaviour
{
    PlayerScript pl;
    GameObject Player;
    Collider2D shotCollider = new Collider2D();
    Transform enemy;
    [SerializeField] float speed = 5;
    [SerializeField] LayerMask enemies;
    Vector3 mouse;
    Vector3 direction;

    void Start()
    {
        Player = GameObject.Find("Player");
        pl = Player.GetComponent<PlayerScript>();
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = -1;
        direction = mouse - transform.position;
    }

    void FixedUpdate()
    {
        if (enemy == null && pl.typeOfShot == 2)
            FindTarget();
        if (pl.typeOfShot == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

            Destroy(gameObject, 3);
        }
        else if (pl.typeOfShot == 2)
        {
            if (enemy == null)
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
            Destroy(gameObject, 6);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void FindTarget()
    {
        shotCollider = Physics2D.OverlapCircle(transform.position, 4f, enemies);
        if(shotCollider != null)
            enemy = shotCollider.gameObject.transform;
    }
}