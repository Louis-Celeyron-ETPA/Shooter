using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPlayer : MonoBehaviour
{
    private int hp = 3;

    public void ReduceHP()
    {
        hp -= 1;
        if (hp<=0)
        {
            //Game Over
        } 
    }


}
