using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticAlternateMovement : MonoBehaviour
{
    [Range(-1,1)]
    public int horizontalSide = 1;
    public Movement movementRef;
    private float timer = 0;
    public float timerMax = 2;


    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            movementRef.SetDirection(Vector2.down + Vector2.right*horizontalSide);
            horizontalSide *= -1;
            timer = timerMax;
        }
    }

}
