using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorObject : MonoBehaviour
{
    #region seagull variables
    [SerializeField] Transform seagull;
    float seagullRate = 5;
    float seagullCoolDown;
    Vector3 seagullPosition;
    #endregion

    void Start()
    {
        #region seagull instantiate variables
        seagullCoolDown = 0;
        seagullPosition.x = -41;
        seagullPosition.z = 0;
        #endregion
    }

    private void Update()
    {
        #region seagullCoolDown
        if (seagullCoolDown > 0)
        {
            seagullCoolDown -= Time.deltaTime;
        }
        #endregion
    }
    private void FixedUpdate()
    {
        #region instantiate seagull
        if (seagullCoolDown <= 0)
        {
            seagullPosition.y = Random.Range(-31, -80);
            seagullCoolDown = seagullRate;
            Instantiate(seagull, seagullPosition, seagull.rotation);
        }
        #endregion
    }

}
