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

        private void Update()
        {
            UpdateState();
            HandleState();
        }

        private void UpdateState()
        {
            if (_detector.Player == null || !_detector.PlayerInRange)
            {
                SwitchState(EnemyState.Idle);
                return;
            }

            if (!_combat.IsInitialized)
            {
                _combat.Init(_detector.Player);
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
                case EnemyState.Attack:
                    _movement.Stop();
                    if (_combat.CanAttack())
                    {
                        _combat.PerformAttack();
                    }
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