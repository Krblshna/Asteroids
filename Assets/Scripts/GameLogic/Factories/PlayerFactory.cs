using Asteroids.Actions;
using Asteroids.Common;
using Asteroids.Effect;
using Asteroids.Enemies;
using Asteroids.Statistics;
using Asteroids.Movers;
using Asteroids.Player;
using Asteroids.PositionValidators;
using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.GameLogic
{
    public class PlayerFactory : IFactory<IPlayer>
    {
        private readonly IEffectsProvider _effectsProvider;
        private GroupType _groupType = GroupType.Ally;
        private readonly IPlayerStat _playerStat;
        private readonly float _bodySize;

        public PlayerFactory(
            IEffectsProvider effectsProvider,
            IPlayerStat playerStat,
            float bodySize = 0.46f
            )
        {
            _effectsProvider = effectsProvider;
            _playerStat = playerStat;
            _bodySize = bodySize;
        }

        public IPlayer Create(Transform transform)
        {
            var borderValidator = new BorderValidator(_bodySize);
            var input = new PlayerInput();
            var laserData = new LaserData(3, 5f, 0.6f, 0.1f);
            var laserModel = new LaserModel(transform, FireType.AltFire, _groupType, laserData);
            var gunModel = new GunModel(FireType.MainFire, _groupType, 0.15f);
            var weapons = new IWeapon[]
            {
                gunModel, laserModel
            };
            var weaponController = new WeaponController(input, weapons);
            var mover = new VelocityMover(transform, borderValidator);
            var rotator = new VelocityRotator(transform);
            var moveController = new MovementController(input, mover, rotator, transform);
            var destroyActions = new IAction[]
            {
                new ParticleAction(_effectsProvider, transform,  EffectType.DeathBig),
            };
            _playerStat.BindData(moveController, laserModel);
            return new Player.Player(moveController, weaponController, input, _groupType, destroyActions);
        }
    }
}