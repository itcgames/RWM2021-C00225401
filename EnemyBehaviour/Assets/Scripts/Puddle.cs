using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    [SerializeField]
    private float timeToLive;

    private float timerReset;

    private void Start()
    {
        timerReset = timeToLive;
    }

    // Update is called once per frame
    void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive < 0)
        {
            timeToLive = timerReset;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //damage player
    }
}
