using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform EnemyVision;
    [SerializeField] LayerMask Players;
    [SerializeField] Transform Player;

    [SerializeField] Transform shot;

    [SerializeField] float enemySpeed = 3;
    
    float shootRate = 1;
    float shootCoolDown;

    void Start()
    {
        shootCoolDown = 0;
    }

    void Update()
    {
        #region Decrease TimeToShoot
        if (shootCoolDown > 0)
        {
            shootCoolDown -= Time.deltaTime;
        }
        #endregion
    }

    private void FixedUpdate()
    {
        #region Enemy Run unto Player

        if (CanSee() && Vector3.Distance(transform.position, Player.transform.position) > 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, enemySpeed * Time.deltaTime);
        }

        var angle = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        #endregion

        #region Ways to enemy atack

        #region Melee atack

        if (IsNear())
        {
        }

        #endregion

        #region shoot
        else if (IsAlmostNear())
        {
            if (shootCoolDown <= 0)
            {
                shootCoolDown = shootRate;
                Instantiate(shot, transform.position, shot.rotation);
            }
        }
        #endregion

        #endregion
    }

    bool CanSee()
    {
        bool canSee;
        canSee = Physics2D.OverlapCircle(EnemyVision.position, 12f, Players);
        return canSee;
    }

    bool IsAlmostNear()
    {
        bool isAlmostNear;
        isAlmostNear = Physics2D.OverlapCircle(EnemyVision.position, 8f, Players);
        return isAlmostNear;
    }

    bool IsNear()
    {
        bool isNear;
        isNear = Physics2D.OverlapCircle(EnemyVision.position, 3.5f, Players);
        return isNear;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShot")
        {
            Destroy(gameObject);
        }

    }
}
