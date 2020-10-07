using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    private Rigidbody2D rb2d;
    private float movement = 0f;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rb2d.velocity = new Vector2(movement * speed, rb2d.velocity.y);
        }
        
        else if (movement< 0f)
        {
            rb2d.velocity = new Vector2(movement * speed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }
}
