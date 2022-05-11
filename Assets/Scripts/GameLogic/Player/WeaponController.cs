using System;
using System.Collections.Generic;
using Asteroids.Common;
using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.Player
{
    public class WeaponController : IWeaponController
    {
        private readonly IInput _input;
        private readonly FireType[] _fireTypes;
        private readonly IDictionary<FireType, IWeapon> _weaponsFireArsenal = new Dictionary<FireType, IWeapon>();
        private readonly IDictionary<WeaponType, IWeapon> _weaponsArsenal = new Dictionary<WeaponType, IWeapon>();

        public WeaponController(IInput input, IWeapon[] weapons)
        {
            _input = input;
            foreach (var weapon in weapons)
            {
                _weaponsFireArsenal.Add(weapon.FireType, weapon);
            }
            foreach (var weapon in weapons)
            {
                _weaponsArsenal.Add(weapon.WeaponType, weapon);
            }
            _fireTypes = (FireType[]) Enum.GetValues(typeof(FireType));
        }

        public IWeapon GetWeapon(WeaponType weaponType)
        {
            return _weaponsArsenal.TryGetValue(weaponType, out var weapon) ? weapon : null;
        }


        public void CustomUpdate()
        {
            foreach (var fireType in _fireTypes)
            {
                if (_input.IsFire(fireType) && _weaponsFireArsenal.TryGetValue(fireType, out var weapon))
                {
                    weapon.Fire();
                }
            }
        }
    }
}