using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float invisibilityFrame;

    Dictionary<GameObject, float> enemyHitTimer;
    Queue<GameObject> expiredEnemyTimer;

    private void Start()
    {
        enemyHitTimer = new Dictionary<GameObject, float>();
        expiredEnemyTimer = new Queue<GameObject>();
    }

    private void Update()
    {
        HandleEnemyTimer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if (!enemyHitTimer.ContainsKey(collision.gameObject))
            {
                damageable.TakeDamage(damage);
                enemyHitTimer.Add(collision.gameObject, Time.time + invisibilityFrame);
            }       
        }
    }

    void HandleEnemyTimer()
    {
        foreach (var timer in enemyHitTimer)
        {
            if(timer.Value < Time.time)
            {
                expiredEnemyTimer.Enqueue(timer.Key);
            }
        }

        while(expiredEnemyTimer.Count > 0)
        {
            enemyHitTimer.Remove(expiredEnemyTimer.Dequeue());
        }
    }
}
