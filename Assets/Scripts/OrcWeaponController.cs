using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcWeaponController : MonoBehaviour
{
    OrcController _orcController;

    private void Start()
    {
        _orcController = transform.root.GetComponent<OrcController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_orcController.IsAttack)
            return;
        collision.GetComponent<PlayerHeath>()?.Hit(20f);
    }
}
