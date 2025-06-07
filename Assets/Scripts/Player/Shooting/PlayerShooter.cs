using UnityEngine;

namespace Player.Shooting
{
    public class PlayerShooter : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] [Min(0.0f)] private float _fireRate;
        [SerializeField] [Min(0.0f)] private float _damage;
        [SerializeField] [Min(0.0f)] private float _bulletSpeed;
        
        [Header("References")]
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private EnemyDetector _enemyDetector;

        private float _nextFireTime;

        public void Shoot()
        {
            if (Time.time < _nextFireTime || _enemyDetector.GetNearestEnemy() == null)
                return;
            
        }
    }
}