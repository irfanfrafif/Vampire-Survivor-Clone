using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            GameManager.Instance.GameOver();
            gameObject.SetActive(false);
        }
    }
}
