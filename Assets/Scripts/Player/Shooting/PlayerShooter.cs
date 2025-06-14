﻿using System;
using UnityEngine;
using UnityEngine.Serialization;
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
        [SerializeField] private PlayerDetector playerDetector;
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private ParticleSystem _muzzleFlashEffect;
        [SerializeField] private Button _shootButton;
        
        [Header("Ammunition")]
        [SerializeField] private AmmoSystem _ammoSystem;

        private float _nextFireTime;

        private void Awake()
        {
            _ammoSystem.Init();
            _shootButton.onClick.AddListener(Shoot);
        }
        
        
        public void Shoot()
        {
            if (Time.time < _nextFireTime || 
                playerDetector.GetNearestEnemy() == null || 
                !_ammoSystem.TryConsumeAmmo())
                return;
            
            Bullet bullet = _bulletPool.GetBullet();
            bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
            
            Vector2 direction = (playerDetector.GetNearestEnemy().position - _firePoint.position).normalized;
            
            bullet.Init(direction, _bulletSpeed, _damage, _bulletPool);
            
            _muzzleFlashEffect.Play();
        }
    }
}