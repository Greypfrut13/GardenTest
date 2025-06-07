using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Shooting
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _initialPoolSize;
        
        private Queue<Bullet> _bullets = new Queue<Bullet>();

        private void Awake()
        {
            for (int i = 0; i < _initialPoolSize; i++)
            {
                AddBulletToPool();
            }
        }

        private void AddBulletToPool()
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform);
            bullet.gameObject.SetActive(false);
            _bullets.Enqueue(bullet);
        }

        public Bullet GetBullet()
        {
            Bullet bullet = _bullets.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }

        public void ReturnBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            bullet.transform.SetParent(transform);
            _bullets.Enqueue(bullet);
        }
    }
}