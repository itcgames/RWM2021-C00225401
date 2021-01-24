using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject puddle;
    [SerializeField]
    private float spawnTimer;

    private Vector3 direction;
    private float timerReset;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(1, 0, 0);
        timerReset = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (direction * speed * Time.deltaTime);

        spawnTimer -= Time.deltaTime;
        if(spawnTimer < 0)
        {
            spawnTimer = timerReset;
            Instantiate(puddle, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
    }

    public void setPuddleTimer(int t_new)
    {
        spawnTimer = t_new;
    }
}
