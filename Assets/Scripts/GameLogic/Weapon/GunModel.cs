using System;
using Asteroids.Common;
using UnityEngine;

namespace Asteroids.Weapon
{
    public interface IGun : IWeapon
    {
        void BindActions(Action onFire);
    }
    public class GunModel : IGun
    {
        public WeaponType WeaponType => WeaponType.Gun;
        public GroupType GroupType { get; }
        public FireType FireType { get; }
        private Action _onFire;
        private float _lastFireTime;
        private readonly float _fireDelay;

        public GunModel(FireType fireType,
            GroupType groupType,
            float fireDelay)
        {
            FireType = fireType;
            GroupType = groupType;
            _fireDelay = fireDelay;
        }
        public void BindActions(Action onFire)
        {
            _onFire = onFire;
        }

        public void Fire()
        {
            if (Time.time - _lastFireTime < _fireDelay) return;
            _lastFireTime = Time.time;
            _onFire?.Invoke();
        }

        public void Update(){}
    }
}