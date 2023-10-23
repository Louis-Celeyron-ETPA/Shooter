using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Color highHPColor, lowHPColor;
    public int hpMax;

    private int currentHP;

    private void Start()
    {
        //Quand je n� mes PV sont �gal a mes PV max et je set ma couleur a ma couleur de base
        currentHP = hpMax;
        spriteRenderer.color = highHPColor;
    }

    //Fonction pour r�duire les HP appell� par la Bullet elle rentre en collision avec moi
    public void ReduceHP()
    {
        currentHP -= 1;
        //Je fais une interpolation lineaire de la couleur par rapport au rapport pv/pvmax (moins j'ai de pv plus ma couleur se rapproche de lowHPColor)
        float ratioHP = (float)currentHP / (float)hpMax;
        spriteRenderer.color = Color.Lerp(lowHPColor, highHPColor, ratioHP);

        //Si mes PV sont inferieur ou �gal � 0 je meurs
        if (currentHP<=0) 
        {
            Die();
        }
    }

    //Fonction de mort
    public void Die() 
    {

        Destroy(gameObject); // Je me detruit
    }
}
