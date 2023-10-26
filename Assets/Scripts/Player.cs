using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float score;
    public event EventHandler OnScoreChanged;
    private int health;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private Image[] healthImages;

    private void Start()
    {
        health = maxHealth;
    }

    public int GetHealth() { return health; }
    public void DecreaseHealth()
    {
        --health;
        UpdateHealthUi();
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHealthUi()
    {
        for (int i = 2; i >= health; --i)
        {
            healthImages[i].color = Color.red;
        }
    }

    private void GameOver()
    {
        Destroy(gameObject);
    }

    public float Score { get { return score; } set { score = value; OnScoreChanged?.Invoke(this, EventArgs.Empty); } }


}