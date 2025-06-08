using System;
using Enemies;
using UnityEngine;

namespace Player.Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _lifeTime = 2f;

        private float _speed;
        private float _damage;
        private Vector2 _direction;
        private BulletPool _bulletPool;

        public void Init(Vector2 direction, float speed, float damage, BulletPool bulletPool)
        {
            _direction = direction;
            _speed = speed;
            _damage = damage;
            _bulletPool = bulletPool;

            GetComponent<Rigidbody2D>().velocity = direction * speed;
            Invoke(nameof(ReturnToPool), _lifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Bullet triggered");
            if (other.TryGetComponent<EnemyHealth>(out var enemyHealth))
            {
                enemyHealth.TakeDamage(_damage);
                ReturnToPool();
            }
        }

        private void ReturnToPool()
        {
            CancelInvoke(nameof(ReturnToPool));
            _bulletPool.ReturnBullet(this);
        }
    }
}