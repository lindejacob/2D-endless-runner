using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private float lastJump = 0.0f;
    private Rigidbody2D rb2d;
    private bool isGrounded;

    public float jumpRate;
    public float jumpPower;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        lastJump += Time.deltaTime;
        AutoJump();
    }

    private void AutoJump()
    {
        if ((isGrounded == true) && (lastJump > jumpRate))
        {
            lastJump -= jumpRate;

            rb2d.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)x
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}
