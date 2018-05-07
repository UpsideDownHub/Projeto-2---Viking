using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] LayerMask Players;
    [SerializeField] Transform Player;
    ShowingEnemyLife sel;
    [SerializeField] GameObject EnemyLifeLabel;
    [SerializeField] GameObject EnemyView;

    [SerializeField] Transform shot;

    FieldOfView fow;

    [SerializeField] float enemySpeed = 3;

    float shootRate = 1;
    float shootCoolDown;
    int totalLife = 3;
    int enemyLife;

    List<Vector2> lastPlayerPositions = new List<Vector2>();
    float lastPositionsRate = 1;
    float lastPositionsCountDown;
    int pos = 0;

    bool justSaw = false;
    float stillLookingRate = 0.25f;
    float stillLookingCountDown;

    List<int> lookAroundAngles = new List<int>() { 90, -90, -90 };
    int anlgesIndex = 0;
    bool look = false;
    float lookAroundRate = 1f;
    float lookAroundCountDown;

    public float StillLookingRate
    {
        get
        {
            return stillLookingRate;
        }

        set
        {
            stillLookingRate = value;
        }
    }

    void Start()
    {
        fow = EnemyView.GetComponent<FieldOfView>();
        enemyLife = totalLife;
        sel = EnemyLifeLabel.GetComponent<ShowingEnemyLife>();
        shootCoolDown = 0;
        lastPositionsCountDown = lastPositionsRate;
    }

    void Update()
    {
        #region Decrease TimeToShoot
        if (shootCoolDown > 0)
        {
            shootCoolDown -= Time.deltaTime;
        }
        #endregion

        if (lastPositionsCountDown > 0)
        {
            lastPositionsCountDown -= Time.deltaTime;
        }

        if (stillLookingCountDown > 0 && !fow.visibleTargets.Contains(Player))
        {
            stillLookingCountDown -= Time.deltaTime;
            justSaw = true;
        }

        if (lookAroundCountDown > 0)
        {
            lookAroundCountDown -= Time.deltaTime;
        }
        if (fow.visibleTargets.Contains(Player))
        {
            anlgesIndex = 0;
            lookAroundCountDown = 0;
            look = false;
        }
        if (look)
        {
            if (lookAroundCountDown <= 0)
            {
                transform.Rotate(0, 0, lookAroundAngles[anlgesIndex]);
                anlgesIndex++;
                if (anlgesIndex == 3)
                {
                    anlgesIndex = 0;
                    look = false;
                }
                else
                {
                    lookAroundCountDown = lookAroundRate;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        #region Enemy Run unto Player

        if (fow.visibleTargets.Contains(Player))
        {
            if (Vector3.Distance(transform.position, Player.transform.position) > 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, enemySpeed * Time.deltaTime);
                if (fow.visibleTargets.Contains(Player))
                {
                    stillLookingCountDown = stillLookingRate;
                    if (lastPositionsCountDown <= 0)
                    {
                        lastPositionsCountDown = lastPositionsRate;
                        lastPlayerPositions.Add(Player.transform.position);
                        if (lastPlayerPositions.Count == 3)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                lastPlayerPositions[i] = lastPlayerPositions[1 + i];
                            }
                            lastPlayerPositions.Remove(lastPlayerPositions[2]);
                        }
                    }
                }
            }
        }
        else if (justSaw)
        {
            if (transform.position != new Vector3(lastPlayerPositions[pos].x, lastPlayerPositions[pos].y, 0.0f))
            {
                transform.position = Vector3.MoveTowards(transform.position, lastPlayerPositions[pos], enemySpeed * Time.deltaTime);
            }
            else
            {
                if (pos < lastPlayerPositions.Count - 1)
                {
                    pos++;
                    if (pos == 2)
                    {
                        pos = 0;
                        justSaw = false;
                        lastPlayerPositions.Clear();
                        lookAroundCountDown = lookAroundRate;
                        look = true;
                    }
                }
                else
                {
                    pos = 0;
                    justSaw = false;
                    lastPlayerPositions.Clear();
                    lookAroundCountDown = lookAroundRate;
                    look = true;
                }
            }
        }

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

        if (enemyLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    bool IsAlmostNear()
    {
        bool isAlmostNear;
        isAlmostNear = Physics2D.OverlapCircle(transform.position, 8f, Players);
        return isAlmostNear;
    }

    bool IsNear()
    {
        bool isNear;
        isNear = Physics2D.OverlapCircle(transform.position, 3.5f, Players);
        return isNear;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShot")
        {
            enemyLife--;
            sel.ShowEnemyLife(enemyLife, totalLife);
        }
    }
}
