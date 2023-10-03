using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : MonoBehaviour
{
	//This makes the goal change its position continuously, as a means of
    //incorporating an element from the ApplePicker Project.
    
    //Speed at which the Goal moves
	private float speed = 3f;

    //Distance where AppleTree turns around
    private float leftAndRightEdge = 4f;

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move right
        }

        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move left
        }
    }
}