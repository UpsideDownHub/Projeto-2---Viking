using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    [SerializeField] float speedWalk = 4;
    [SerializeField] float speedRun = 5;
    [SerializeField] Transform shot;
    float speed;
    Vector2 move;

    Rigidbody2D rb = new Rigidbody2D();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        #region Player Moviment
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
        #endregion
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(shot, transform.position, shot.rotation);
        }
    }

    #region Land Collision
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
    #endregion
    
}
