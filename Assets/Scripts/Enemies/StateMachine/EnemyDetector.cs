using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class EnemyDetector : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _detectionRadius;
        [SerializeField] private LayerMask _playerLayer;
        
        private CircleCollider2D _circleCollider2D;
        
        public Transform Player { get; private set; }
        public bool PlayerInRange { get; private set; }

        private void Awake()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _circleCollider2D.radius = _detectionRadius;
            _circleCollider2D.isTrigger = true;
        }

        private void Update()
        {
            PlayerInRange = Player != null &&  
                            Vector2.Distance(transform.position, Player.position) <= _detectionRadius;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & _playerLayer) != 0)
            {
                Player = other.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform == Player)
            {
                Player = null;
                PlayerInRange = false;
            }
        }
    }
}