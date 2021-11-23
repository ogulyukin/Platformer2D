using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private Animator animator;
    private bool isFacingRight = true;

    private Finish finish;
    private bool _finish = false;

    private LeverArm leverArm;
    private bool isLeverArm = false;

    private float speedX = 0;
    private const float speedMultiplier = 100f;
    private bool isGround = false;
    private bool isJump = false;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        _finish = false;
        leverArm = FindObjectOfType<LeverArm>();
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

        if(Input.GetKeyDown(KeyCode.F))
        {   
            if(_finish)
                finish.FinishLever();
            if(isLeverArm)
                leverArm.ActivateLeverArm();                
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Finish"))
        {
            _finish = true;
        }

        if (other.GetComponent<LeverArm>())
        {
            isLeverArm = true;
        }    
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            _finish = false;
        }

        if (other.GetComponent<LeverArm>())
        {
            isLeverArm = false;
        }
    }

    private void changeScale()
    {
        Vector3 playersScale = transform.localScale;
        playersScale.x *= -1;
        transform.localScale = playersScale;
    }
}
