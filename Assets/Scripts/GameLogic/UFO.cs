using Asteroids.Actions;
using Asteroids.Common;
using Asteroids.HitDetectors;
using Asteroids.Movers;

namespace Asteroids.GameLogic
{
    public class UFO : IEnemy
    {
        public IMoveController MoveController { get; }
        public IAction[] DestroyActions { get; }
        public GroupType GroupType { get; } = GroupType.Enemy;

        public UFO(IMoveController moveController, IAction[] destroyActions)
        {
            MoveController = moveController;
            DestroyActions = destroyActions;
        }

        public void OnCreate()
        {
            MoveController.Move();
        }

        public void OnDestroy()
        {
            MoveController.DoOnDestroy();
            foreach (var destroyEvent in DestroyActions)
            {
                destroyEvent.Call();
            }
        }

        public void Update()
        {
            MoveController.Update();;
        }
    }
}