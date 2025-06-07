using System;
using Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Shooting
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class EnemyDetector : MonoBehaviour
    {
        [SerializeField] private float _detectionRadius;
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private Button _shootButton;

        private Transform _nearestEnemy;

        private void Awake()
        {
            GetComponent<CircleCollider2D>().radius = _detectionRadius;
            GetComponent<CircleCollider2D>().isTrigger = true;
            _shootButton.interactable = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & _enemyLayer) != 0)
            {
                _nearestEnemy = other.transform;
                _shootButton.interactable = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform == _nearestEnemy)
            {
                _nearestEnemy = null;
                _shootButton.interactable = false;
            }
        }
    }
}