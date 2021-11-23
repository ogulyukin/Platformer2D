using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private float speedX = 0;
    private const float speedMultiplier = 100f;
    private bool isGround = false;
    private bool isJump = false;
    private bool isFacingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal");
        animator.SetFloat("speedX", Mathf.Abs(speedX));
        if(Input.GetKey(KeyCode.W) && isGround)
        {
            isGround = false;
            isJump = true;
        }

        if(speedX > 0f && !isFacingRight)
        {
            isFacingRight = true;
            changeScale();
        }

        if (speedX < 0f && isFacingRight)
        {
            isFacingRight = false;
            changeScale();
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

    private void changeScale()
    {
        Vector3 playersScale = transform.localScale;
        playersScale.x *= -1;
        transform.localScale = playersScale;
    }
}
