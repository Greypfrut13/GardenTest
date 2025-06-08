using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyCombat : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _attackRange;
        [SerializeField] [Min(0.0f)] private float _attackCoolDown;
        [SerializeField] [Min(0.0f)] private float _damage;

        private float _lastAttackTime;
        private Transform _player;

        public float AttackRange => _attackRange;
        public bool IsInitialized { get; private set; }

        public void Init(Transform playerTarget)
        {
            if (playerTarget == null)
            {
                return;
            }
            
            _player = playerTarget;
            IsInitialized = true;
        }

        public bool CanAttack()
        {
            if (!IsInitialized || _player == null)
            {
                return false;
            }
            
            return Time.time - _lastAttackTime >= _attackCoolDown &&
                   Vector2.Distance(transform.position, _player.position) <= _attackRange;
        }

        public void PerformAttack()
        {
            if (_player.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(_damage);
                _lastAttackTime = Time.time;
            }
        }
    }
}