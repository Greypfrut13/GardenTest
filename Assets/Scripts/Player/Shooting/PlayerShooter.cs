using System;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private EnemyDetector _enemyDetector;
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private Button _shootButton;
        [SerializeField] private ParticleSystem _muzzleFlashEffect;

        private float _nextFireTime;

        private void Start()
        {
            _shootButton.onClick.AddListener(Shoot);
        }

        public void Shoot()
        {
            if (Time.time < _nextFireTime || _enemyDetector.GetNearestEnemy() == null)
                return;
            
            Bullet bullet = _bulletPool.GetBullet();
            bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
            
            Vector2 direction = (_enemyDetector.GetNearestEnemy().position - _firePoint.position).normalized;
            
            bullet.Init(direction, _bulletSpeed, _damage, _bulletPool);
            
            _muzzleFlashEffect.Play();
        }
    }
}