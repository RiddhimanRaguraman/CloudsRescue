using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapPlayer : MonoBehaviour
{
   public float moveSpeed = 5f;
   public Rigidbody2D rb;
   Vector2 movement;
   public Joystick js;

    // Update is called once per frame
    void Update()
    {
        movement.x = js.Horizontal;
        movement.y = js.Vertical;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
