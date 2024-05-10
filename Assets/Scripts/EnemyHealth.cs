using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float health;
    [SerializeField] float score;
    float maxHealth;
    [SerializeField] SpriteRenderer spriteRenderer;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;

            spriteRenderer.color = new Color(1, health / maxHealth, health / maxHealth, 1);
            if(health <= 0 )
            {
                HandleDeath();
            }
        }
    }

    private void Start()
    {
        maxHealth = health;
    }

    private void HandleDeath()
    {
        GameManager.Instance.score += score;
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
