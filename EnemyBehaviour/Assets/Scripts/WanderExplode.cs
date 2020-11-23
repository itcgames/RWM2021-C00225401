using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderExplode : MonoBehaviour
{
    [SerializeField]
    public Transform targetPos;
    [SerializeField]
    public float speed;
    [SerializeField]
    public GameObject room;
    [SerializeField]
    public bool clockwise;
    [SerializeField]
    private float moveCounter;

    private float roomW;
    private float roomH;


    enum dir { North, South, East, West };
    [SerializeField]
    private dir moveDirection;

  //  private Rigidbody2D rb2d;
    private SpriteRenderer roomSprite;
    private SpriteRenderer enemySprite;

    void Start()
    {
        //moveDirection = dir.North;
        roomSprite = room.GetComponent<SpriteRenderer>();
        enemySprite = GetComponent<SpriteRenderer>();
        roomW = roomSprite.bounds.size.x;
        roomH = roomSprite.bounds.size.y;
    }

    private void Update()
    {
        moveCounter -= Time.deltaTime;
    }

    void LateUpdate()
    {
        if (moveCounter >= 0)
        {
            moveAroundRoom();
        }
    }

    void changeDirection()
    {
        if (moveDirection == dir.North)
        {
            moveDirection = dir.South;
        }
        else if (moveDirection == dir.South)
        {
            moveDirection = dir.North;
        }
        else if (moveDirection == dir.East)
        {
            moveDirection = dir.West;
        }
        else if (moveDirection == dir.West)
        {
            moveDirection = dir.East;
        }
    }

    void moveAroundRoom()
    {
        if (moveDirection == dir.North)
        {
            if (transform.position.y + (enemySprite.bounds.size.y) < room.transform.position.y + (roomH / 2))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            }
            else
            {
                if (clockwise)
                {
                    moveDirection = dir.East;
                }
                else
                {
                    moveDirection = dir.West;
                }
            }
        }
        else if (moveDirection == dir.South)
        {
            if (transform.position.y - (enemySprite.bounds.size.y) > room.transform.position.y - (roomH / 2))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            }
            else
            {
                if (clockwise)
                {
                    moveDirection = dir.West;
                }
                else
                {
                    moveDirection = dir.East;
                }
            }
        }
        else if (moveDirection == dir.East)
        {
            if (transform.position.x + (enemySprite.bounds.size.x) < room.transform.position.x + (roomW / 2))
            {
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            }
            else
            {
                if (clockwise)
                {
                    moveDirection = dir.South;
                }
                else
                {
                    moveDirection = dir.North;
                }
            }
        }
        else if (moveDirection == dir.West)
        {
            if (transform.position.x - (enemySprite.bounds.size.x) > room.transform.position.x - (roomW / 2))
            {
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            }
            else
            {
                if (clockwise)
                {
                    moveDirection = dir.North;
                }
                else
                {
                    moveDirection = dir.South;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        changeDirection();
        if(clockwise)
        {
            clockwise = false;
        }
        else
        {
            clockwise = true;
        }
    }

    public float getCounter()
    {
        return moveCounter;
    }

    public void setDir(int direction)
    {
        moveDirection = (dir)direction;
    }
}
