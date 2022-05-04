using System;
using Asteroids.Common;
using Asteroids.Effect;
using Asteroids.GameManagement;
using Asteroids.Utility;
using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.Player
{
    public class Player : MonoBehaviour, IDestructible
    {
        private GroupType _groupType = GroupType.Ally;
        private IMovementController _movementController;
        private WeaponController _weaponController;
        private IInput _input;
        
        private float ship_size = 0.46f;

        void Awake()
        {
            var body = GetComponent<Rigidbody2D>();
            _input = GetComponent<IInput>();
            _movementController = GetComponent<IMovementController>();
            _movementController.Init(_input, transform);
            _weaponController = GetComponentInChildren<WeaponController>();
            _weaponController.Init(_input, _groupType);
        }

        public Rigidbody2D GetBody()
        {
            return GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            _input.CustomUpdate();
            _weaponController.CustomUpdate();
            _movementController.CustomUpdate();
            transform.position = ScreenData.ValidatePos(transform.position, ship_size);
        }

        public bool Hit(GroupType hitGroup)
        {
            if (hitGroup == _groupType) return false;
            gameObject.SetActive(false);
            EffectsManager.Instance.CreateEffect(EffectType.DeathBig, transform.position);
            GameManager.Instance.Finish();
            return true;
        }

        public void Hit()
        {
            throw new NotImplementedException();
        }
    }
}