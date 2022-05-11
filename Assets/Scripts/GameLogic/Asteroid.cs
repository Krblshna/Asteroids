using Asteroids.Actions;
using Asteroids.Common;
using Asteroids.Enemies;
using Asteroids.HitDetectors;
using Asteroids.Movers;
using Asteroids.Test2;

namespace Asteroids.GameLogic
{
    public class Asteroid : IEnemy
    {
        private readonly IMoveController _moveController;
        private readonly IAction[] _destroyActions;
        public GroupType GroupType { get; } = GroupType.Enemy;

        public Asteroid(IMoveController moveController, IAction[] destroyActions)
        {
            _moveController = moveController;
            _destroyActions = destroyActions;
        }

        public void Update()
        {
            _moveController.Update();
        }

        public void OnCreate()
        {
            _moveController.Move();
        }

        public void OnDestroy()
        {
            _moveController.DoOnDestroy();
            foreach (var destroyEvent in _destroyActions)
            {
                destroyEvent.Call();
            }
        }
    }
}