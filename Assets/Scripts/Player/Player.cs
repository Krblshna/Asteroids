using System;
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
            _movementController.Init(_input, body);
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
            transform.position = ScreenPortal.ValidatePos(transform.position, ship_size);
        }

        void FixedUpdate()
        {
            _movementController.CustomFixedUpdate();
        }

        public bool Hit(GroupType hitGroup)
        {
            if (hitGroup == _groupType) return false;
            gameObject.SetActive(false);
            EffectsManager.Instance.CreateEffect(EffectType.DeathBig, transform.position);
            GameManager.Instance.Finish();
            return true;
        }
    }
}