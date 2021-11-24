using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private bool _isAttack;
    [SerializeField] private Animator animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isAttack = true;
            animator.SetTrigger("attack");
        }

        if (Input.GetMouseButtonDown(1))
        {
            _isAttack = true;
            animator.SetTrigger("special");
        }
    }
}
