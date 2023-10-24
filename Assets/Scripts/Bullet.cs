using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public GameObject vfx;

    public float maxLifeTime;


    private float _lifetime;
    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;
    }

    private void Update()
    {
        //On ajoute a lifetime le temps qu'il s'est passé depuis la derniere frame
        _lifetime += Time.deltaTime; 

        //On Detruit la balle si elle depase un certain temps de vie
        if(_lifetime>=maxLifeTime)
        {
            Destroy(gameObject);
        }


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
