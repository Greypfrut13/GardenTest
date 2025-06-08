using System;
using Player.Shooting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies
{
    public class EnemyStateMachine : MonoBehaviour
    {
        private enum EnemyState { Idle, Chase, Attack}
        
        [Header("Dependencies")]
        [SerializeField] private EnemyDetector _detector;
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private EnemyCombat _combat;
        
        private EnemyState _currentState;

        private void Start()
        {
            
        }

        private void Update()
        {
            UpdateState();
            HandleState();
        }

        private void UpdateState()
        {
            if (!_detector.PlayerInRange)
            {
                SwitchState(EnemyState.Idle);
                return;
            }

            _currentState = Vector2.Distance(transform.position, _detector.Player.position) <= _combat.AttackRange
                ? EnemyState.Attack
                : EnemyState.Chase;
        }

        private void HandleState()
        {
            switch (_currentState)
            {
                case EnemyState.Idle:
                    _movement.Stop();
                    break;
                case EnemyState.Chase:
                    _movement.SetTarget(_detector.Player);
                    _movement.MoveToTarget();
                    break;
            }
        }

        private void SwitchState(EnemyState newState)
        {
            if(_currentState == newState) return;
            _currentState = newState;
        }
    }
}