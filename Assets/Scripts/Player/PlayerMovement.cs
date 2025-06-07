using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private Joystick _joystick;
        
        private Rigidbody2D _rigidbody;

        public void Init(PlayerCore core)
        {
            _rigidbody = core.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector2 direction = _joystick.Direction;
            _rigidbody.velocity = direction * _movementSpeed;
        }
    }
}