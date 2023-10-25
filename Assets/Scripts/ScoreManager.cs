using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI textMeshProReference;
    public Animator animator;

    public void AddScore(int amount)
    {
        score += amount;
        animator.SetTrigger("Trigger");
        textMeshProReference.text = score.ToString("000000");
    }

}
