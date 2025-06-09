using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemyDrop : MonoBehaviour
    {
        [SerializeField] private EnemyDropItem[] _dropItems;

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
            int randomIndex = Random.Range(0, _dropItems.Length);
            EnemyDropItem dropItem = _dropItems[randomIndex];
            
            Instantiate(dropItem, transform.position, Quaternion.identity);
        }
    }
}