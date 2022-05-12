using Asteroids.GameLogic.Actions;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Movers;

namespace Asteroids.GameLogic.Enemies
{
    public class UFO : IEnemy
    {
        private readonly IMoveController _moveController;
        private readonly IAction[] _destroyActions;
        public GroupType GroupType { get; } = GroupType.Enemy;

        public UFO(IMoveController moveController, IAction[] destroyActions)
        {
            _moveController = moveController;
            _destroyActions = destroyActions;
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

        public void Update()
        {
            _moveController.Update();;
        }
    }
}