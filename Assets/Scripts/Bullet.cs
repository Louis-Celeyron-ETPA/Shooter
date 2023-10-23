using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public GameObject vfx;
    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemyCollided = collision.gameObject.GetComponent<Enemy>();
        if(enemyCollided == true)
        {
            enemyCollided.ReduceHP();
        }
        
        Instantiate(vfx, transform.position, vfx.transform.rotation);
        Destroy(gameObject);
    }

}
