using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector3 newPos;

    // moves player to mouse click position for testing purposes 
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }
}
