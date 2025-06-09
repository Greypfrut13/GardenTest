using System;
using Enemies;
using UnityEngine;

namespace Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [SerializeField] private EnemyStateMachine _enemyPrefab;
        [SerializeField] [Min(0)] private int _spawnAmount = 3;
        
        [Header("Spawn Area Limits")]
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _minY;
        [SerializeField] private float _maxY;
        
        [Header("Player Exclusion Zone")]
        [SerializeField] private float _exclusionRadius;

        [SerializeField] private Transform _player;

        private void Start()
        {
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < _spawnAmount; i++)
            {
                Vector2 spawnPosition = GetValidSpawnPosition();
                if (spawnPosition != Vector2.zero)
                {
                    Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
                }
                else
                {
                    Debug.LogWarning($"Failed to spawn enemy {i + 1} - no valid position found");
                }
            }
        }
        
        private Vector2 GetValidSpawnPosition()
        {
            int attempts = 0;
            const int maxAttempts = 30; 
            
            while (attempts < maxAttempts)
            {
                Vector2 randomPosition = new Vector2(
                    UnityEngine.Random.Range(_minX, _maxX),
                    UnityEngine.Random.Range(_minY, _maxY)
                );
                
                if (Vector2.Distance(randomPosition, _player.position) > _exclusionRadius)
                {
                    Collider2D collider = Physics2D.OverlapCircle(randomPosition, 0.5f);
                    if (collider == null)
                    {
                        return randomPosition;
                    }
                }
                
                attempts++;
            }
            
            return Vector2.zero;
        }
    }
}