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


    private bool awake = true;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if (awake)
        {
            moveToTarget();
        }
    }

    void moveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
    }
}
