using System;
using Asteroids.GameLogic.Common;
using UnityEngine;

namespace Asteroids.GameLogic.Weapon
{
    public class LaserModel : ILaser, ILaserData
    {
        private readonly Transform _transform;
        private readonly LaserData _laserData;
        private Action _onActivate;
        private Action _onDeactivate;

        public GroupType GroupType { get; }
        public FireType FireType { get; }
        public WeaponType WeaponType { get; } = WeaponType.Laser;
        public int Ammo { get; private set; }
        public float LaserCooldown => Ammo >= _laserData.MaxAmmo ? 0 : _laserData.AmmoRecoveryTime - _currentRecoveryTime;

        private float _currentRecoveryTime;
        private float _lastFireTime;

        public LaserModel(Transform transform, 
            FireType fireType, 
            GroupType groupType, 
            LaserData laserData)
        {
            _transform = transform;
            FireType = fireType;
            GroupType = groupType;
            _laserData = laserData;
            Ammo = _laserData.MaxAmmo;
        }

        public void BindActions(Action onActivate, Action onDeactivate)
        {
            _onActivate = onActivate;
            _onDeactivate = onDeactivate;
        }

        public void Update()
        {
            RecoverAmmo();
        }

        private void RecoverAmmo()
        {
            if (Ammo >= _laserData.MaxAmmo) return;
            if (_currentRecoveryTime >= _laserData.AmmoRecoveryTime)
            {
                _currentRecoveryTime = 0;
                Ammo++;
            }
            else
            {
                _currentRecoveryTime += Time.deltaTime;
            }
        }

        public void Fire()
        {
            if (Ammo < 1) return;
            if (Time.time > _laserData.FireDelay && Time.time - _lastFireTime < _laserData.FireDelay) return;
            Ammo--;
            _lastFireTime = Time.time;
            ActivateLaser();
        }

        private void DeactivateLaser()
        {
            _onDeactivate?.Invoke();

        }

        private void ActivateLaser()
        {
            _onActivate?.Invoke();
            Utils.Instance.setTimeOut(DeactivateLaser, _laserData.LaserLifeTime);
        }
    }
}