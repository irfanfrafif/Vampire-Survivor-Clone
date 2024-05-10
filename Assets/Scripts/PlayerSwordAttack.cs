using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordAttack : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    // Animation
    [SerializeField] Animator animator;
    [SerializeField] float attackDelayFromStart;

    // Attack Parameter
    [SerializeField] float damage;
    [SerializeField] float attackInterval;
    float attackTimer;

    // Hitbox Parameter
    [SerializeField] Vector2 swordHitboxSize;
    [SerializeField] Collider2D attackHitbox;
    Collider2D[] hitResults;
    ContactFilter2D filter2D;
    int maxHits = 100;

    // Debug
    [SerializeField] bool toggleAutoAttack = true;   
    
    // Probably shit code, see comment below
    Vector3 attackHitboxPos;
    Vector3 attackHitboxPosFlipped;

    private void Start()
    {
        // Need this because when facing left, only the sprite is flipped, not the attack hitbox. Hitbox
        // position needs to adjust. This is probably too hacky, and needs improvement.
        attackHitboxPos = transform.localPosition;
        attackHitboxPosFlipped = new Vector3(-attackHitboxPos.x, attackHitboxPos.y);

        // Set how many enemy can be hit it one attack
        hitResults = new Collider2D[maxHits];
    }

    void Update()
    {
        HandleAttack();
    }

    void HandleAttack()
    {
        if (!toggleAutoAttack) return;

        attackTimer += Time.deltaTime;
        if (attackTimer < attackInterval) return;

        StartCoroutine(SwordAttack());
        attackTimer = 0;
    }

    IEnumerator SwordAttack()
    {
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(attackDelayFromStart);

        // Adjust attack hitbox position
        transform.localPosition = (playerMovement.facingLeft) ? attackHitboxPosFlipped : attackHitboxPos;

        int hits = attackHitbox.OverlapCollider(filter2D.NoFilter(), hitResults);

        for(int i = 0; i < hits; i++)
        {
            if (hitResults[i].isTrigger && hitResults[i].TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
        }
    }

    public void MultiplyAttackInterval(float multiplier)
    {
        attackInterval *= multiplier;
    }
}
