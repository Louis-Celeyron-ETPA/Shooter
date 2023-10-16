using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLoop : MonoBehaviour
{
    public Transform limitL;
    public Transform limitR;

    // Update is called once per frame
    void Update()
    {
        CheckScreenLoop();        
    }

    private void CheckScreenLoop()
    {
        if (transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }
    }
}
