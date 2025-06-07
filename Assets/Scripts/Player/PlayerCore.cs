using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerCore : MonoBehaviour
    {
        [FormerlySerializedAs("_playerMovement")]
        [Header("References")]
        [SerializeField] private PlayerMovement _movement;

        private void Awake()
        {
            _movement.Init(this);
        }
    }
}