using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;

    private Rigidbody2D rb;
    private Vector2 position;
    private Vector2 input;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input.x < 0.0f)
        {
            sprite.flipX = true;
        }
        else if (input.x > 0.0f)
        {
            sprite.flipX = false;
        }

        if (IsMoving() || Input.GetMouseButton(0))
        {
            animator.SetBool("IsActing", true);
        }
        else
        {
            animator.SetBool("IsActing", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
    }

    private bool IsMoving()
    {
        return input.x != 0.0f || input.y != 0.0f;
    }
}
