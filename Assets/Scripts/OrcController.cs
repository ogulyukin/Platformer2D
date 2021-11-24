using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float timeToWait = 5;
    private const float _speedMultiplier = 100f;
    private float _patrolDistanse = 12f;
    private float _speedX = 1;

    private Rigidbody2D _rb;
    private Vector2 _leftPosition;
    private Vector2 _rigtPosition;
    private bool _isFacingRight = true;
    private float _waitTime;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _leftPosition = transform.position;
        _rigtPosition = _leftPosition + new Vector2(1, 0) * _patrolDistanse;
        _waitTime = timeToWait;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<OrkVision>().FindTarget)
        {
            startchasingPlayer();
        }
        else
        {
            walkDirection();
        }
        animator.SetFloat("speedX", Mathf.Abs(_speedX));
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_speedX * _speedMultiplier * Time.fixedDeltaTime, _rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftPosition, _rigtPosition);
    }

    public bool GetDirection() 
    {
        return _isFacingRight;
    }

    private void walkDirection()
    {
        animator.SetBool("attack", false);
        if (_isFacingRight && transform.position.x >= _rigtPosition.x)
        {
            if (_waitTime > 0f)
            {
                doWait();
            }
            else
            {
                continuePatrol(false);
            }
        }

        if (!_isFacingRight && transform.position.x <= _leftPosition.x)
        {
            if (_waitTime > 0f)
            {
                doWait();
            }
            else
            {
                continuePatrol(true);
            }
        }
    }

    private void doWait()
    {
        _waitTime -= Time.deltaTime;
        _speedX = 0f;
    }

    private void continuePatrol(bool direction)
    {
        _speedX = direction ? 1f : -1f;
        _isFacingRight = direction;
        changeScale();
        _waitTime = timeToWait;
    }

    private void changeScale()
    {
        Vector3 playersScale = transform.localScale;
        playersScale.x *= -1f;
        transform.localScale = playersScale;
    }

    private void startchasingPlayer()
    {
        if(GetComponent<OrkVision>().GetDistance() < 1.5f)
        {
            _speedX = 0f;
            var rand = new System.Random();
            if (rand.Next(0, 3) == 0)
            {
                animator.SetTrigger("attack");
            }
            else
            {
                animator.SetTrigger("special");
            }           
        }
        else
        {          
            _speedX = _isFacingRight ? 1.5f : -1.5f;
        }        
    }
}
