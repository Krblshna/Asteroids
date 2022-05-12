using System;
using Asteroids.GameLogic;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Player;
using Asteroids.GameLogic.Weapon;
using Asteroids.View.HitDetectors;
using UnityEngine;

namespace Asteroids.View.Player
{
    public class PlayerView : MonoBehaviour, IFollowable, IPlayerView
    {
        public bool Active => gameObject.activeSelf;
        public Vector3 GetPos() => transform.position;

        private IHitDetector _hitDetector;
        public IPlayer Player { get; private set; }
        public IMoverData MoverData => (IMoverData) Player.MovementController;
        public ILaserData LaserData;
        private Action _onDestroy;

        public void Init(Action onDestroy)
        {
            _onDestroy = onDestroy;
            Player = Logic.PlayerFactory.Create(transform);
            _hitDetector = GetComponentInChildren<IHitDetector>();
            _hitDetector.Init(Player.GroupType, Hit);
            var weaponControllerView = GetComponentInChildren<WeaponControllerView>();
            weaponControllerView.Init(Player.WeaponController);
        }
        
        void Update()
        {
            Player.Update();
        }

        public void Hit(DamageType damageType)
        {
            gameObject.SetActive(false);
            Player.OnDestroy();
            _onDestroy();
        }
    }
}