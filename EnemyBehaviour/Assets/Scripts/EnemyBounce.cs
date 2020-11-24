using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounce : MonoBehaviour
{
    private Vector3 move;

    [SerializeField]
    private float speed;
    [SerializeField]
    public GameObject room;
    [SerializeField]
    private GameObject spawn;
    [SerializeField]
    private float spawnTimer;

    private SpriteRenderer roomSprite;
    private Rigidbody2D rgby;
    private Vector3 dir;
    private float spawnReset;

    // Start is called before the first frame update
    void Start()
    {
        move = new Vector3(1.0f, 1.0f, 0.0f);
        roomSprite = room.GetComponent<SpriteRenderer>();
        rgby = GetComponent<Rigidbody2D>();
        rgby.AddForce(new Vector3(1.0f, 1.0f, 0.0f) * speed);
        spawnReset = spawnTimer;
    }

    private void LateUpdate()
    {
        spawnTimer -= Time.deltaTime;
        boundryCheck();
    }

    private void split()
    {
        if (spawnTimer <= 0)
        {
            spawnTimer = spawnReset;
            GameObject enemy1 =  Instantiate(spawn);
            GameObject enemy2 =  Instantiate(spawn);
            enemy1.transform.SetParent(transform.parent);
            enemy2.transform.SetParent(transform.parent);
            Destroy(this.gameObject);
        }
    }

    private void boundryCheck()
    {
        // bottom
        if(transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2) < room.transform.position.y - (roomSprite.bounds.size.y / 2))
        {
            dir = new Vector3(transform.position.x, room.transform.position.y, 0.0f) - transform.position;
            dir = dir.normalized;
            rgby.AddForce(dir * (speed / 5));
        }
        // top
        if (transform.position.y + (GetComponent<SpriteRenderer>().bounds.size.y / 2) > room.transform.position.y + (roomSprite.bounds.size.y / 2))
        {
            dir = new Vector3(transform.position.x, room.transform.position.y, 0.0f) - transform.position;
            dir = dir.normalized;
            rgby.AddForce(dir * (speed / 5));
        }
        //left
        if (transform.position.x - (GetComponent<SpriteRenderer>().bounds.size.x / 2) < room.transform.position.x - (roomSprite.bounds.size.x / 2))
        {
            dir = new Vector3(room.transform.position.x, transform.position.y, 0.0f) - transform.position;
            dir = dir.normalized;
            rgby.AddForce(dir * (speed / 5));
        }
        //right
        if (transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2) > room.transform.position.x + (roomSprite.bounds.size.x / 2))
        {
            dir = new Vector3(room.transform.position.x, transform.position.y, 0.0f) - transform.position;
            dir = dir.normalized;
            rgby.AddForce(dir * (speed / 5));
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            split(); 
        }
        dir = new Vector3(c.contacts[0].point.x, c.contacts[0].point.y, 0.0f);
        dir -= transform.position;
        dir = -dir.normalized;
        rgby.AddForce(dir * speed);
    }
}
