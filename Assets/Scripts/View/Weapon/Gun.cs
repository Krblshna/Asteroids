using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Weapon;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.View.Weapon
{
    public class Gun : MonoBehaviour, IWeaponView
    {
        public WeaponType WeaponType => WeaponType.Gun;

        private ObjectPool<IBullet> _pool;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _fireDelay = 0.1f;
        [SerializeField] private float _bulletSpeed = 10f;
        [SerializeField] private float _bulletLifeTime = 2f;
        private IFireDirection _fireDirection;
        private GroupType _groupType;
        private IGun _gun;

        public void CustomUpdate(){}
        private void Awake()
        {
            _fireDirection = GetComponent<IFireDirection>();
            _pool = new ObjectPool<IBullet>(CreateBullet, OnGet, OnRelease);
        }

        public void Init(IWeapon weapon)
        {
            if (weapon is IGun gun)
            {
                _gun = gun;
                _gun.BindActions(Fire);
            }

            _groupType = weapon.GroupType;
        }

        public void Fire()
        {
            var bullet = _pool.Get();
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