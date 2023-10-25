using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public float timerMax = 0.5f;
    private float timerBetTwoBullets;
  
    public void SpawnBullet()
    {
        timerBetTwoBullets -= Time.deltaTime;
        if(timerBetTwoBullets<=0)
        {
            Instantiate(bullet, parent.position, parent.rotation);
            timerBetTwoBullets = timerMax;
        }
    }
}
