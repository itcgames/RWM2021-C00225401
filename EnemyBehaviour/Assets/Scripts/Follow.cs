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
    [SerializeField]
    public static float FOV = 360.0f;

    private bool awake = true;
    private float angle = 0.0f;
    private static int raycount = 5;
    private float angleIncrease = FOV / raycount;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var dir = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));
        bool seen = false;
        Vector3 vertex = new Vector3(0,0,0);
        //RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, dir, wakeRadius);
        //for (int i = 0; i < raycount; i++)
        //{
        //    if (raycastHit.collider.gameObject.name == "Player")
        //    {
        //        vertex = raycastHit.point;
        //        awake = true;
        //        seen = true;
        //    }
        //    Debug.DrawRay(vertex, dir * wakeRadius, Color.green);
        //}
        if (!seen)
        {
            vertex = transform.position + dir * wakeRadius;
            //awake = false;
        }
        if (awake)
        {
            seen = false;
            moveToTarget();
        }
    }

    void moveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
    }
}
