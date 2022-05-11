using Asteroids.Common;
using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.Player
{
    public class WeaponControllerView : MonoBehaviour
    {
        private IWeaponController _weaponController;
        private IWeaponView[] _weaponViews;

        public void Init(IWeaponController weaponController)
        {
            _weaponController = weaponController;
            _weaponViews = GetComponentsInChildren<IWeaponView>();
            foreach (var weaponView in _weaponViews)
            {
                var weaponType = weaponView.WeaponType;
                var weaponModel = _weaponController.GetWeapon(weaponType);
                weaponView.Init(weaponModel);
            }
        }

        private void Update()
        {
            _weaponController.CustomUpdate();
            foreach (var weaponView in _weaponViews)
            {
                weaponView.CustomUpdate();
            }
        }
    }
}