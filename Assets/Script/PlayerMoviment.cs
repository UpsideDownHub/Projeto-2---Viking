using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    [SerializeField] float speedWalk = 5;
    [SerializeField] float speedRun = 4;
    float speed;
    Vector2 move;

    //BoxCollider2D bc = new BoxCollider2D();
    //SpriteRenderer sr = new SpriteRenderer();
    Rigidbody2D rb = new Rigidbody2D();

    // Use this for initialization
    void Start()
    {
        //bc = GetComponent<BoxCollider2D>();
        //sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bc.gameObject.layer == LayerMask.NameToLayer("Ice"));

        if (Input.GetKey(KeyCode.LeftShift))
            speed = speedRun;
        else
            speed = speedWalk;

        if (speedRun == 4)
        {
            move.x = Input.GetAxis("Horizontal") * 2 * Time.deltaTime;
            move.y = Input.GetAxis("Vertical") * 3 * Time.deltaTime;
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
