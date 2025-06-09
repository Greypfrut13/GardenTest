using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        public UnityEvent OnDeath;
        
        [Header("Settings")]
        [SerializeField] [Min(0.0f)] private float _maxHealth;
        
        [Header("UI")]
        [SerializeField] private Slider _healthSlider;
        
        private float _currentHealth;

        private void Start()
        {
            _currentHealth = _maxHealth; 
            
            _healthSlider.maxValue = _maxHealth;
            _healthSlider.value = _currentHealth;
            _healthSlider.gameObject.SetActive(false);

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
            _healthSlider.gameObject.SetActive(true);
            _healthSlider.value = _currentHealth;
        }
        
        private void Die()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}