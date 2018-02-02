using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMoviment : MonoBehaviour
{


    //[SerializeField] float shotSpeed = 10;
    //[SerializeField] Rigidbody2D shotPrefab;
    //[SerializeField] float shootingRate = 0.5f;
    private float shootingCoolDown;
    Vector3 mousePosition;

    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = -1;
        shootingCoolDown = 0;
    }

    void Update()
    {

        if (shootingCoolDown > 0)
        {
            shootingCoolDown -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, mousePosition, 5 * Time.deltaTime);
    }







    //public void CallShoot(Vector2 mousePosition)
    //{
    //    if (shootingCoolDown <= 0)
    //    {
    //        shootingCoolDown = shootingRate;

    //        var shotTransform = Instantiate(shotPrefab) as Rigidbody2D;
    //        shotTransform.position = transform.position;
    //        Instantiate(shotPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

    //        shotTransform.velocity += new Vector2(5 * Time.deltaTime, 5 * Time.deltaTime);
    //        Shoot(mousePosition, shotTransform);
    //    }

    //}
    //public void Shoot(Vector2 mousePosition, Transform shotTransform)
    //{
    //    Debug.Log(shotTransform.position);
    //    shotTransform.position = Vector3.MoveTowards(shotTransform.position, mousePosition, 0 * Time.deltaTime);

    //    Debug.Log(shotTransform.position);
    //    if (shotTransform.position == new Vector3(mousePosition.x, mousePosition.y, 0))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
