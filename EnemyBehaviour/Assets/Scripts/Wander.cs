using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
    }
}
