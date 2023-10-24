using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Color highHPColor, lowHPColor;
    public int hpMax;
    public GameObject vfxPrefab;

    public Rigidbody2D enemyRigidbody2D;

    public bool startRight;
    public float speed = 0.5f;

    private int currentHP;
    private float timer;

    private void Start()
    {
        //Quand je né mes PV sont égal a mes PV max et je set ma couleur a ma couleur de base
        currentHP = hpMax;
        spriteRenderer.color = highHPColor;
        
        enemyRigidbody2D.velocity = Vector2.down;
        enemyRigidbody2D.velocity += startRight?Vector2.left:Vector2.right;
        enemyRigidbody2D.velocity *= speed;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer>=2)
        {
            timer = 0;
            enemyRigidbody2D.velocity = new Vector2(enemyRigidbody2D.velocity.x*-1,enemyRigidbody2D.velocity.y);

        }
    }

    //Fonction pour réduire les HP appellé par la Bullet elle rentre en collision avec moi
    public void ReduceHP()
    {
        currentHP -= 1;
        //Je fais une interpolation lineaire de la couleur par rapport au rapport pv/pvmax (moins j'ai de pv plus ma couleur se rapproche de lowHPColor)
        float ratioHP = (float)currentHP / (float)hpMax;
        spriteRenderer.color = Color.Lerp(lowHPColor, highHPColor, ratioHP);

        //Si mes PV sont inferieur ou égal à 0 je meurs
        if (currentHP<=0) 
        {
            Die();
        }
    }

    //Fonction de mort
    public void Die() 
    {
        var deathVfx = Instantiate(vfxPrefab, transform.position, vfxPrefab.transform.rotation);
        ParticleSystem.MainModule module = deathVfx.GetComponent<ParticleSystem>().main;
        module.startColor = spriteRenderer.color;        
        Destroy(gameObject); // Je me detruit
    }
}
