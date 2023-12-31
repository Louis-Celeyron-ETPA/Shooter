using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Color highHPColor, lowHPColor;
    public int hpMax;
    public GameObject vfxPrefab;

    public ScoreManager scoreManagerReference;

    private int currentHP;

    private void Start()
    {
        //Quand je n� mes PV sont �gal a mes PV max et je set ma couleur a ma couleur de base
        currentHP = hpMax;
        spriteRenderer.color = highHPColor;
        scoreManagerReference = FindObjectOfType<ScoreManager>();
    }


    //Fonction pour r�duire les HP appell� par la Bullet elle rentre en collision avec moi
    public void ReduceHP()
    {
        currentHP -= 1;
        //Je fais une interpolation lineaire de la couleur par rapport au rapport pv/pvmax (moins j'ai de pv plus ma couleur se rapproche de lowHPColor)
        float ratioHP = (float)currentHP / (float)hpMax;
        spriteRenderer.color = Color.Lerp(lowHPColor, highHPColor, ratioHP);
        scoreManagerReference.AddScore(1);

        //Si mes PV sont inferieur ou �gal � 0 je meurs
        if (currentHP<=0) 
        {
            scoreManagerReference.AddScore(10);
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

    //Se d�truit au contact du joueur mais lui inflige des d�gats
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HPPlayer player = collision.GetComponent<HPPlayer>();
        if(player == true)
        {
            player.ReduceHP();
        }
        Die();
    }
}
