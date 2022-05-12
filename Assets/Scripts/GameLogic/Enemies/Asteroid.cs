using Asteroids.GameLogic.Actions;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Movers;

namespace Asteroids.GameLogic.Enemies
{
    public interface ICouldSplit
    {
        void OnSplit();
    }
    public class Asteroid : IEnemy, ICouldSplit
    {
        private readonly IMoveController _moveController;
        private readonly IAction[] _destroyActions;
        private readonly IAction[] _splitActions;
        public GroupType GroupType { get; } = GroupType.Enemy;

        public Asteroid(IMoveController moveController, IAction[] destroyActions, IAction[] splitActions = null)
        {
            _moveController = moveController;
            _destroyActions = destroyActions;
            _splitActions = splitActions;
        }

        public void Update()
        {
            _moveController.Update();
        }

        public void OnCreate()
        {
            _moveController.Move();
        }

        public void OnSplit()
        {
            if (_splitActions == null) return;
            foreach (var damageEvent in _splitActions)
            {
                damageEvent.Call();
            }
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