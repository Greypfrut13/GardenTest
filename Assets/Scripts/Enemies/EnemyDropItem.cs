using System;
using Player.Inventory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class EnemyDropItem : MonoBehaviour
    {
        [SerializeField] private Item _item;
        [SerializeField] [Min(1)] private int _minDropAmount;
        [SerializeField] [Min(1)] private int _maxDropAmount;

        
        [Header("Pickup Settings")]
        [SerializeField] [Min(0.0f)] private float _pickingRadius;
        [SerializeField] private LayerMask _playerLayer;
        
        private CircleCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
            _collider.isTrigger = true;
            _collider.radius = _pickingRadius;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & _playerLayer) != 0)
            {
                InventorySystem inventory = other.gameObject.GetComponent<InventorySystem>();
                
                TryPickup(inventory);
            }
        }

        private void TryPickup(InventorySystem inventory)
        {
            int randomAmount = Random.Range(_minDropAmount, _maxDropAmount + 1);
            
            if (inventory != null && inventory.AddItem(_item, randomAmount))
            {
                Destroy(gameObject);
            }
        }
    }
}