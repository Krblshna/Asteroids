using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Weapon
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        private ObjectPool<IBullet> _pool;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _fireDelay = 0.1f;
        [SerializeField] private float _bulletSpeed = 10f;
        [SerializeField] private float _bulletLifeTime = 2f;
        private float _lastFireTime;

        private void Awake()
        {
            _pool = new ObjectPool<IBullet>(CreateBullet, OnGet, OnRelease);
        }

        public void Fire()
        {
            if (Time.time - _lastFireTime < _fireDelay) return;
            var bullet = _pool.Get();
            _lastFireTime = Time.time;
        }

        IBullet CreateBullet()
        {
            var bulletObj = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            var bullet = bulletObj.GetComponent<IBullet>();
            bullet.Init(_bulletSpeed, _bulletLifeTime, _pool.Release);
            return bullet;
        }

        void OnGet(IBullet bullet)
        {
            bullet.SetActive(true);
            bullet.OnActivate(transform.position, transform.rotation * Vector2.up);
        }

        void OnRelease(IBullet bullet)
        {
            bullet.SetActive(false);
        }
    }
}