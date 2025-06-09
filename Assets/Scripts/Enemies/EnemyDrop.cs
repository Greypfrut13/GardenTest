using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemyDrop : MonoBehaviour
    {
        [SerializeField] private EnemyDropItem _dropItem;

        [SerializeField] private EnemyHealth _enemyHealth;

        private void Awake()
        {
            _enemyHealth.OnDeath.AddListener(HandleDeath);
        }

        private void OnDestroy()
        {
            _enemyHealth.OnDeath.RemoveListener(HandleDeath);
        }

        private void HandleDeath()
        {
            CreateDropInWorld();
        }

        private void CreateDropInWorld()
        {
            EnemyDropItem dropItem = Instantiate(_dropItem, transform.position, Quaternion.identity);
        }
    }
}