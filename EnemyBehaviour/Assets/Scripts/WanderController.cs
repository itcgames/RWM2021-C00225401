using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderController : MonoBehaviour 
{
    private WanderExplode script;

    public Transform targetPos; 
    [SerializeField]
    public float speed; 
    [SerializeField]
    public GameObject room; 
    [SerializeField]
    public bool clockwise; 
    [SerializeField]
    private float moveCounter; 
    // Start is called before the first frame update
    void Start()
    {
        script = new WanderExplode();
        script.setRoom(room);
        script.setRoomSprite(room.GetComponent<SpriteRenderer>());
        script.setEnemySprite(GetComponent<SpriteRenderer>());
        script.setDir(0);
        script.setCounter(moveCounter);
        script.setTarget(targetPos);
        script.setSpeed(speed);
        script.setClockwise(clockwise);
        script.setCounter(moveCounter);
    }

    // Update is called once per frame
    void Update()
    {
        script.update();
    }

    private void LateUpdate()
    {
        script.lateUpdate(transform);
    }

    public void setCounter(float t_new)
    {
        script.setCounter(t_new);
    }

    public float getCounter()
    {
        return script.getCounter();
    }
}
