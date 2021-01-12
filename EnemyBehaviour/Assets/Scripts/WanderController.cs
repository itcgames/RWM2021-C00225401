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
        script.setDir(0);
        script.setCounter(moveCounter);
        script.setCounter(moveCounter);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
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
