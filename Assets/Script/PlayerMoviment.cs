using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    [SerializeField] float speedWalk = 4;
    [SerializeField] float speedRun = 5;
    float speed;
    Vector2 move;
    
    Rigidbody2D rb = new Rigidbody2D();
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
            speed = speedRun;
        else
            speed = speedWalk;

        if (speedRun == 4)
        {
            move.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            move.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            rb.velocity += move;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            Vector3 moveLand = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, Input.GetAxis("Vertical") * Time.deltaTime);
            transform.position += moveLand * speed;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ice"))
        {
            speedRun = 4;
            speedWalk = 3;
        }
        else
        {
            speedRun = 5;
            speedWalk = 4;
        }
    }
}
