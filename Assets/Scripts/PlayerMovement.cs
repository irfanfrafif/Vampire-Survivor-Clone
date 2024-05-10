using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 moveDirection;
    public bool facingLeft;

    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator animator;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        HandleMovement();
        HandleAnimation();
    }

    void HandleMovement()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        transform.Translate(speed * Time.deltaTime * moveDirection.normalized);

        // Determines whether sprite is facing left or right based on mouse position
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePos - transform.position;

        facingLeft = lookDirection.x < 0;
        sprite.flipX = facingLeft;
    }

    void HandleAnimation()
    {
        // Set "IsMoving" parameter on animation controller
        bool isMoving = (moveDirection.sqrMagnitude != 0);
        animator.SetBool("IsMoving", isMoving);
    }
}
