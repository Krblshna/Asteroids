using Asteroids.Utility;
using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject mainWeaponObj, altWeaponObj;
        private IInput _input;
        private IWeapon _mainWeapon, _altWeapon;
        public void Init(IInput input, GroupType groupType)
        {
            _input = input;
            _mainWeapon = mainWeaponObj.GetComponent<IWeapon>();
            _altWeapon = altWeaponObj.GetComponent<IWeapon>();

            _mainWeapon.Init(groupType);
            _altWeapon.Init(groupType);
        }

        public void CustomUpdate()
        {
            if (_input.Fire)
            {
                _mainWeapon.Fire();
            }

            if (_input.AltFire)
            {
                _altWeapon.Fire();
            }
        }
    }
}