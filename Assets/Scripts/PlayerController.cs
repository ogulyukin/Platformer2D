using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private Animator animator;
    private bool _isFacingRight = true;

    private Finish _isFinish;
    private bool _finish = false;

    private LeverArm _leverArm;
    private bool _isLeverArm = false;

    private float _speedX = 0;
    private const float _speedMultiplier = 100f;
    private bool _isGround = false;
    private bool _isJump = false;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _isFinish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        _finish = false;
        _leverArm = FindObjectOfType<LeverArm>();
    }

    // Update is called once per frame
    void Update()
    {
        _speedX = Input.GetAxis("Horizontal");
        animator.SetFloat("speedX", Mathf.Abs(_speedX));
        if(Input.GetKeyDown(KeyCode.W) && _isGround)
        {
            _isGround = false;
            _isJump = true;
        }

        if(_speedX > 0f && !_isFacingRight)
        {
            _isFacingRight = true;
            changeScale();
        }

        if (_speedX < 0f && _isFacingRight)
        {
            _isFacingRight = false;
            changeScale();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {   
            if(_finish)
                _isFinish.FinishLever();
            if(_isLeverArm)
                _leverArm.ActivateLeverArm();                
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_speedX * _speedMultiplier * Time.fixedDeltaTime, rb.velocity.y);
        if(_isJump)
        {
            rb.AddForce(new Vector2(0f, 500f));
            _isJump = false;
            jumpSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
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
            _isLeverArm = true;
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
            _isLeverArm = false;
        }
    }

    private void changeScale()
    {
        Vector3 playersScale = transform.localScale;
        playersScale.x *= -1;
        transform.localScale = playersScale;
        GetComponent<PlayerHeath>().invertSlider(_isFacingRight);
    }
}
