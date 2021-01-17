using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuck : MonoBehaviour
{
    [SerializeField]
    private float suckRadius;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject player;

    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        if ((playerPos - transform.position).magnitude < suckRadius)
        {
            Vector3 attraction = (playerPos - transform.position).normalized;
            player.transform.position = playerPos - (attraction * (speed * Time.deltaTime));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //player loses health
    }
}
