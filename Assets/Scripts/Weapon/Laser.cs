using Asteroids.Common;
using Asteroids.Utility;
using Asteroids.Weapon.FireDirection;
using UnityEngine;

namespace Asteroids.Weapon
{
    public class Laser : MonoBehaviour, IWeapon
    {
        public int Ammo { get; private set; }
        public float LaserCooldown => Ammo >= _maxAmmo ? 0 : _ammoRecoveryTime - _currentRecoveryTime;
        [SerializeField] private float _currentRecoveryTime;
        [SerializeField] private int _maxAmmo = 3;
        [SerializeField] private int _ammoRecoveryTime = 5;
        [SerializeField] private float _fireDelay = 5f;
        [SerializeField] private float _laserLifeTime = 1f;
        [SerializeField] private IFireDirection _fireDirection;
        private LineRenderer _laserLine;
        private float _lastFireTime;
        private GroupType _groupType;
        private bool _active;

        private void Update()
        {
            RecoverAmmo();
            if (!_active) return;
            UpdatePos();
        }

        private void RecoverAmmo()
        {
            if (Ammo >= _maxAmmo) return;
            if (_currentRecoveryTime >= _ammoRecoveryTime)
            {
                _currentRecoveryTime = 0;
                Ammo++;
            }
            else
            {
                _currentRecoveryTime += Time.deltaTime;
            }
        }

        private void UpdatePos()
        {
            _laserLine.SetPositions(new Vector3[]
            {
                transform.position,
                transform.position + (Vector3)_fireDirection.GetDirection() * 30
            });
        }

        public void Init(GroupType groupType)
        {
            Ammo = _maxAmmo;
            _groupType = groupType;
            _fireDirection = GetComponent<IFireDirection>();
            _laserLine = GetComponentInChildren<LineRenderer>(true);
            GetComponentInChildren<Damager>(true).Init(_groupType);
        }

        public void Fire()
        {
            if (Ammo < 1) return;
            if (Time.time > _fireDelay && Time.time - _lastFireTime < _fireDelay) return;
            ActivateLaser();
            Ammo--;
            _lastFireTime = Time.time;
        }

        private void SetLaser(bool active)
        {
            _active = active;
            _laserLine.gameObject.SetActive(active);
        }

        private void DeactivateLaser()
        {
            SetLaser(false);
        }

        private void ActivateLaser()
        {
            SetLaser(true);
            UpdatePos();
            Utils.Instance.setTimeOut(DeactivateLaser, _laserLifeTime);
        }
    }
}