using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float attackInterval;
    float attackTimer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (Time.time > attackTimer)
            {
                AttackPlayer(collision.gameObject);
                attackTimer = Time.time + attackInterval;
            }
        }
    }

    void AttackPlayer(GameObject player)
    {
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
