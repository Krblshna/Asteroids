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
        public IMoveController MoveController { get; }
        public IAction[] DestroyActions { get; }
        public GroupType GroupType { get; } = GroupType.Enemy;

        public Asteroid(IMoveController moveController, IAction[] destroyActions)
        {
            MoveController = moveController;
            DestroyActions = destroyActions;
        }

        public void Update()
        {
            MoveController.Update();
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
    }
}