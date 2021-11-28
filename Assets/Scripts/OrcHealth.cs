using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrcHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float totalHealth = 100f;
    [SerializeField] private float _health;

    private void Start()
    {
        InitHealth();
    }
    public void Hit(float dammage)
    {
        _health -= dammage;
        healthSlider.value = _health / totalHealth;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void InitHealth()
    {
        _health = totalHealth;
        healthSlider.value = _health / totalHealth;
    }

    public void invertSlider(bool direction)
    {
        healthSlider.direction = direction ? Slider.Direction.LeftToRight : Slider.Direction.RightToLeft;
    }
}
