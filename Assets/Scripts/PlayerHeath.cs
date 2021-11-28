using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeath : MonoBehaviour
{
    [SerializeField] private AudioSource dammageSound;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float totalHealth = 100f;
    [SerializeField] private Animator animator;

    private float _health;
    private bool _isAlive = true;
    public bool IsAlive { get => _isAlive; }

    private void Start()
    {
        InitHealth();
    }

    public void Hit(float dammage)
    {
        _health -= dammage;
        animator.SetTrigger("hit");
        healthSlider.value = _health / totalHealth;
        dammageSound.Play();
        if (_health <= 0 && _isAlive)
            Die();
    }

    private void Die()
    {
        animator.SetTrigger("die");
        healthSlider.gameObject.SetActive(false);
        _isAlive = false;
    }

    public void Death()
    {
        gameObject.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void invertSlider(bool direction)
    {
        healthSlider.direction = direction ? Slider.Direction.LeftToRight : Slider.Direction.RightToLeft;
    }

    private void InitHealth()
    {
        _health = totalHealth;
        healthSlider.value = _health / totalHealth;
    }

}
