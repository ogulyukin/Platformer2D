using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private Animator animator;
    private bool _isAttack;

    public bool IsAttack { get => _isAttack; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isAttack = true;
            animator.SetTrigger("attack");
            attackSound.Play();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _isAttack = true;
            animator.SetTrigger("special");
            attackSound.Play();
        }
    }

    public void FinishAttack()
    {
        _isAttack = false;
    }
}
