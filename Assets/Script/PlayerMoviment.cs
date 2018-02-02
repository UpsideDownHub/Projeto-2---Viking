﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    [SerializeField] float speedWalk = 4;
    [SerializeField] float speedRun = 5;
    [SerializeField] Transform shot;
    float shootRate = 0.5f;
    float shootCoolDown;

    float speed;
    Vector2 move;

    Rigidbody2D rb = new Rigidbody2D();

    void Start()
    {
        shootCoolDown = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (shootCoolDown > 0)
        {
            shootCoolDown -= Time.deltaTime;
        }

        #region PlayerMoviment
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
        if (shootCoolDown <= 0 && Input.GetButtonDown("Fire1"))
        {
            shootCoolDown = shootRate;
            Instantiate(shot, transform.position, shot.rotation);
        }
    }

    #region LandCollision
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ice"))
        {
            speedRun = 4;
            speedWalk = 3;
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            speedRun = 3;
            speedWalk = 2;
        }
        else
        {
            speedRun = 5;
            speedWalk = 4;
        }
    }
    #endregion

}