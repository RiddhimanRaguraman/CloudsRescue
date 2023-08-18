using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRoad : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public FloatingJoystick js;

    // Update is called once per frame
    void Update()
    {
        movement.x = js.Horizontal;
        movement.y = js.Vertical;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}