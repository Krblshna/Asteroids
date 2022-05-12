using Asteroids.GameLogic.Actions;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Enemies;
using Asteroids.GameLogic.PositionValidators;
using Asteroids.GameLogic.Providers;
using Asteroids.GameLogic.Weapon;
using Asteroids.GameLogic.Movers;
using Asteroids.GameLogic.Player;
using UnityEngine;

namespace Asteroids.GameLogic.Factories
{
    public class PlayerFactory : IFactory<IPlayer>
    {
        private readonly IEffectsProvider _effectsProvider;
        private GroupType _groupType = GroupType.Ally;
        private readonly IPlayerStat _playerStat;
        private readonly IPosProvider _posProvider;
        private readonly float _bodySize;

        public PlayerFactory(
            IEffectsProvider effectsProvider,
            IPosProvider posProvider,
            IPlayerStat playerStat,
            float bodySize = 0.46f
            )
        {
            _effectsProvider = effectsProvider;
            _posProvider = posProvider;
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
            _posProvider.Init(transform);
            return new Player.Player(moveController, weaponController, input, _groupType, destroyActions);
        }
    }
}