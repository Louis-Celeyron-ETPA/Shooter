using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform parent;
    public float speed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(Vector3.right);
        }
      
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction * speed;
    }


}
