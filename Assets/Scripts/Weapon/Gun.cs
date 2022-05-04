using Asteroids.Common;
using Asteroids.Weapon.FireDirection;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Weapon
{
    public class Gun : MonoBehaviour, IWeapon
    {
        private ObjectPool<IBullet> _pool;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _fireDelay = 0.1f;
        [SerializeField] private float _bulletSpeed = 10f;
        [SerializeField] private float _bulletLifeTime = 2f;
        [SerializeField] private IFireDirection _fireDirection;
        private float _lastFireTime;
        private GroupType _groupType;

        private void Awake()
        {
            _fireDirection = GetComponent<IFireDirection>();
            _pool = new ObjectPool<IBullet>(CreateBullet, OnGet, OnRelease);
        }

        public void Init(GroupType groupType)
        {
            _groupType = groupType;
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
            bullet.Init(_groupType, _bulletSpeed, _bulletLifeTime, _pool.Release);
            return bullet;
        }

        void OnGet(IBullet bullet)
        {
            bullet.SetActive(true);
            bullet.OnActivate(transform.position, _fireDirection.GetDirection());
        }

        void OnRelease(IBullet bullet)
        {
            bullet.SetActive(false);
        }
    }
}