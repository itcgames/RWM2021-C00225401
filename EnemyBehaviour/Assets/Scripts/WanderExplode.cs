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

    private float moveReset;

    private float roomW;
    private float roomH;


    enum dir { North, South, East, West, moveToward, moveAway };
    [SerializeField]
    private dir moveDirection;

    private dir prevDirection;

    //  private Rigidbody2D rb2d;
    private SpriteRenderer roomSprite;
    private SpriteRenderer enemySprite;

    private Vector3 startPos;

    void Start()
    {
        prevDirection = dir.North;
        roomSprite = room.GetComponent<SpriteRenderer>();
        enemySprite = GetComponent<SpriteRenderer>();
        roomW = roomSprite.bounds.size.x;
        roomH = roomSprite.bounds.size.y;
        startPos = transform.position;
        moveReset = moveCounter;
    }

    private void Update()
    {
        if (moveDirection != dir.moveAway && moveDirection != dir.moveToward)
        {
            moveCounter -= Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        if (moveDirection == dir.North || moveDirection == dir.South || moveDirection == dir.East || moveDirection == dir.West)
        {
            moveAroundRoom();
            if(moveCounter < 0)
            {
                prevDirection = moveDirection;
                moveDirection = dir.moveToward;
                startPos = transform.position;
                moveCounter = moveReset;
            }
        }
        else
        {
            moveTowardPlayer();
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

    void moveTowardPlayer()
    {
        if(moveDirection == dir.moveToward)
        {
            Vector3 move = targetPos.position - transform.position;
            move = move / Vector3.Distance(transform.position , targetPos.position);
            move = move * speed;
            transform.position = new Vector3(transform.position.x + move.x, transform.position.y + move.y, transform.position.z + move.z);
            if (Vector3.Distance(transform.position, targetPos.position) < 0.1f)
            {
                moveDirection = dir.moveAway;
            }
        } 
        else if(moveDirection == dir.moveAway)
        {
            Vector3 move = startPos - transform.position;
            move = move / Vector3.Distance(transform.position, startPos);
            move = move * speed;
            transform.position = new Vector3(transform.position.x + move.x, transform.position.y + move.y, transform.position.z + move.z);
            if (Vector3.Distance(transform.position, startPos) < 0.1f)
            {
                moveDirection = prevDirection;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (moveDirection != dir.moveAway && moveDirection != dir.moveToward)
        {
            changeDirection();
            if (clockwise)
            {
                clockwise = false;
            }
            else
            {
                clockwise = true;
            }
        }
        else
        {
            if(moveDirection == dir.moveToward)
            {
                moveDirection = dir.moveAway;
            }
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

    public int getDir()
    {
        return (int)moveDirection;
    }

    public void setCounter(float t_new)
    {
        moveCounter = t_new;
    }
}
