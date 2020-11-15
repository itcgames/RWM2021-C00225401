using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    public Transform targetPos;
    [SerializeField]
    public float wakeRadius;
    [SerializeField]
    public float speed;


    public bool awake = false;
    public bool ignoreCollisions = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(targetPos.position, transform.position);
        if (dist <= wakeRadius)
        {
            awake = true;
        }
        if(awake)
        {
            moveToTarget();
        }
    }

    void moveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(ignoreCollisions)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }
    }
}
