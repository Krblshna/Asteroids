using Asteroids.Utility;
using Asteroids.Weapon.FireDirection;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Weapon
{
    public class Laser : MonoBehaviour, IWeapon
    {
        [SerializeField] private float _fireDelay = 5f;
        [SerializeField] private float _laserLifeTime = 1f;
        [SerializeField] private IFireDirection _fireDirection;
        private LineRenderer _laserLine;
        private float _lastFireTime;
        private GroupType _groupType;
        private bool _active = false;

        private void Update()
        {
            if (!_active) return;
            UpdatePos();
        }

        private void UpdatePos()
        {
            Debug.Log($"Update line {Time.time}");
            _laserLine.SetPositions(new Vector3[]
            {
                transform.position,
                transform.position + (Vector3)_fireDirection.GetDirection() * 30
            });
        }

        public void Init(GroupType groupType)
        {
            _groupType = groupType;
            _fireDirection = GetComponent<IFireDirection>();
            _laserLine = GetComponentInChildren<LineRenderer>(true);
            GetComponentInChildren<Damager>(true).Init(_groupType);
        }

        public void Fire()
        {
            if (Time.time > _fireDelay && Time.time - _lastFireTime < _fireDelay) return;
            ActivateLaser();
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