using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Weapon;
using UnityEngine;

namespace Asteroids.View.Weapon
{
    public class Laser : MonoBehaviour, IWeaponView
    {
        public WeaponType WeaponType => WeaponType.Laser;
        private ILaser _laser;
        private IFireDirection _fireDirection;
        private GroupType _groupType;
        private LineRenderer _laserLine;
        private float _lastFireTime;
        private bool _active;

        public void CustomUpdate()
        {
            _laser.Update();
            UpdatePos();
        }

        private void UpdatePos()
        {
            if (!_active) return;
            _laserLine.SetPositions(new Vector3[]
            {
                transform.position,
                transform.position + (Vector3)_fireDirection.GetDirection() * 30
            });
        }

        public void Init(IWeapon weapon)
        {
            if (weapon is ILaser laser)
            {
                _laser = laser;
                laser.BindActions(ActivateLaser, DeactivateLaser);
            }

            _fireDirection = GetComponent<IFireDirection>();
            _laserLine = GetComponentInChildren<LineRenderer>(true);
            GetComponentInChildren<Damager>(true).Init(weapon.GroupType);
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
        }
    }
}