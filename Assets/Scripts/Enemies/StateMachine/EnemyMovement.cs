using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _speed;
        [SerializeField] [Min(0.0f)] private float _stoppingDistance;
        
        private Rigidbody2D _rigidbody;
        private Transform _target;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void MoveToTarget()
        {
            if (_target == null) return;
            
            float distance = Vector2.Distance(transform.position, _target.position);
            if (distance > _stoppingDistance)
            {
                Vector2 direction = (_target.position - transform.position).normalized;
                _rigidbody.velocity = direction * _speed;
            }
            else
            {
                Stop();
            }
        }

        public void Stop()
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}