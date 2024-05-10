using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject target;

    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator anim;

    private void Start()
    {
        target = GameManager.Instance.player;
    }
    void Update()
    {
        HandleMovement();
        HandleAnimation();
    }

    void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void HandleAnimation()
    {
        Vector2 moveVector = target.transform.position - transform.position;

        bool isMoving = moveVector.sqrMagnitude != 0;
        anim.SetBool("IsMoving", isMoving);

        if(moveVector.x != 0)
        {
            sprite.flipX = moveVector.x > 0;
        }
    }
}
