using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    private AttackController _attackController;

    private void Start()
    {
        _attackController = transform.root.GetComponent<AttackController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_attackController.IsAttack)
            return;
        collision.GetComponent<OrcHealth>()?.Hit(20f);
        hitSound.Play();
    }
}
