using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticAlternateMovement : MonoBehaviour
{
    [Range(0.01f,4)]
    public float range = 4;
    public Movement movementRef;


    private void Update()
    {
        movementRef.SetDirection(Vector2.down + Vector2.right*Mathf.Sin(Time.time*range));
    }

}
