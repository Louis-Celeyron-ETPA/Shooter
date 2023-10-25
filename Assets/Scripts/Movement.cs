using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public Vector2 initialDirection;
    public float speed = 7;

    private void Start()
    {
        SetDirection(initialDirection);
    }

    public void SetDirection(Vector2 direction)
    {
        myRigidbody2D.velocity = direction * speed;
    }

    public void Stop()
    {
        myRigidbody2D.velocity = Vector2.zero;
    }

}
