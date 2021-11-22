using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speedX = 0;
    private float speedMultiplier = 100f;
    bool isGround = false;
    bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.W) && isGround)
        {
            isGround = false;
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speedX * speedMultiplier * Time.fixedDeltaTime, rb.velocity.y);
        if(isJump)
        {
            rb.AddForce(new Vector2(0f, 500f));
            isJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
