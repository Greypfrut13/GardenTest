using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] [Min(0.0f)] private float _maxHealth;
        
        [Header("UI")]
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private GameObject _deathScreen;
        
        private float _currentHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;
            UpdateHealthUI();
            _deathScreen.SetActive(false);
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            UpdateHealthUI();

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void UpdateHealthUI()
        {
            _healthSlider.value = _currentHealth / _maxHealth;
        }

        private void Die()
        {
            Time.timeScale = 0;
            _deathScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}