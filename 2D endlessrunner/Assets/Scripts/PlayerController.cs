using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    private Rigidbody2D rb2d;
    private Vector2 RefVelocity = Vector2.zero;
    private bool isGrounded;

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
        if ((isGrounded == true) && (Input.GetButtonDown("Jump")))
        {
            {
                rb2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float xAxis = Input.GetAxis("Horizontal") * speed;

        Vector2 TargetVelocity = new Vector2(xAxis * speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, TargetVelocity, ref RefVelocity, 0.15f);
    }
}
