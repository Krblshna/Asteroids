using System;
using Asteroids.Actions;
using Asteroids.Common;
using Asteroids.Effect;
using Asteroids.Utility;
using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.Player
{
    public class Player : IPlayer
    {
        public GroupType GroupType { get; }
        public IWeaponController WeaponController { get; }
        public IMovementController MovementController { get; }
        private readonly IInput _input;
        private readonly IAction[] _destroyActions;

        public Player(IMovementController movementController, 
            IWeaponController weaponController, 
            IInput input, 
            GroupType groupType, 
            IAction[] destroyActions)
        {
            MovementController = movementController;
            WeaponController = weaponController;
            _input = input;
            _destroyActions = destroyActions;
            GroupType = groupType;
        }

        public void Update()
        {
            _input.CustomUpdate();
            WeaponController.CustomUpdate();
            MovementController.CustomUpdate();
        }

        public void OnDestroy()
        {
            foreach (var action in _destroyActions)
            {
                action.Call();
            }

            _input.OnDestroy();
        }
    }
}