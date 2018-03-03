using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speedWalk = 4;
    [SerializeField] float speedRun = 5;
    [SerializeField] Transform shot;
    [SerializeField] Transform playerFoot;
    [SerializeField] int playerLife;
    [SerializeField] GameObject Item;
    [SerializeField] Animator playerAnimator;
    float shootRate = 1f;
    float shootCoolDown;
    string kinfOfFlour;

    public int typeOfShot = 1;
    float speed;
    Vector2 move;
    Vector3 target;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        shootCoolDown = 0;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        #region Decrease TimeToShoot
        if (shootCoolDown > 0)
        {
            shootCoolDown -= Time.deltaTime;
        }
        #endregion


        playerAnimator.SetFloat("speedX", Input.GetAxis("Horizontal"));
        playerAnimator.SetFloat("speedY", Input.GetAxis("Vertical"));

        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            sr.flipX = false;
        }
    }

    private void FixedUpdate()
    {

        #region PlayerMoviment
        if (Input.GetKey(KeyCode.LeftShift))
            speed = speedRun;
        else
            speed = speedWalk;

        if (kinfOfFlour == "Ice")
        {
            move.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            move.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            rb.velocity += move;

        }
        else
        {
            rb.velocity = new Vector2(0, 0);

            float lastInputX = Input.GetAxis("Horizontal");
            float lastInputY = Input.GetAxis("Vertical");

            if (lastInputX != 0 || lastInputY != 0)
            {
                playerAnimator.SetBool("walking", true);
                if (lastInputX > 0)
                {
                    playerAnimator.SetFloat("lastMoveX", 1f);
                }else if(lastInputX < 0)
                {
                    playerAnimator.SetFloat("lastMoveX", -1f);
                }
                else
                {
                    playerAnimator.SetFloat("lastMoveX", 0f);
                }

                if(lastInputY > 0)
                {
                    playerAnimator.SetFloat("lastMoveY", 1f);
                }else if(lastInputY < 0)
                {
                    playerAnimator.SetFloat("lastMoveY", 1f);
                }
                else
                {
                    playerAnimator.SetFloat("lastMoveY", 0f);
                }
            }
            else
            {
                playerAnimator.SetBool("walking", false);
            }


            

            Vector3 moveLand = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, Input.GetAxis("Vertical") * Time.deltaTime);
            transform.position += moveLand * speed;
        }
        #endregion

        #region Turn Player

        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //target.z = 0f;

        //var angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle);

        #endregion

        #region Shoot
        if (shootCoolDown <= 0 && Input.GetButtonDown("Fire1"))
        {
            shootCoolDown = shootRate;
            Instantiate(shot, transform.position, shot.rotation);
        }
        #endregion
    }

    #region LandCollision
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "EnemyShot")
        {
            playerLife--;
        }

        if (collision.gameObject.tag == "Item")
        {
            Destroy(Item);
            typeOfShot = 2;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ice"))
        {
            kinfOfFlour = "Ice";
            speedRun = 4;
            speedWalk = 3;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            kinfOfFlour = "Water";
            speedRun = 3;
            speedWalk = 2;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Land"))
        {
            kinfOfFlour = "Land";
            speedRun = 5;
            speedWalk = 4;
        }
    }
    #endregion


    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), playerLife.ToString());
    }
}
