using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    public KeyCode left, right, shoot;

    public Movement movementRef;

    private bool leftPressed,rightPressed;

    void Update()
    {
        if(Input.GetKeyDown(left))
        {
            movementRef.SetDirection(Vector2.left);
            leftPressed = true;
        }
        if (Input.GetKeyUp(left))
        {
            leftPressed = false;
            if(rightPressed == true)
            {
                movementRef.SetDirection(Vector2.right);
            }
        }

        if (Input.GetKeyDown(right))
        {
            movementRef.SetDirection(Vector2.right);
            rightPressed = true;
        }
        if (Input.GetKeyUp(right))
        {
            rightPressed = false;
            if (leftPressed== true)
            {
                movementRef.SetDirection(Vector2.left);
            }
        }


        if(rightPressed == false && leftPressed == false)
        {
            movementRef.Stop();
        }
    }
}
