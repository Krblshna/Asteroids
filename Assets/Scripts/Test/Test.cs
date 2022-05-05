using Asteroids.Actions;
using Asteroids.Common;
using Asteroids.HitDetectors;
using Asteroids.Movers;
using UnityEngine;

namespace Asteroids.Test
{
    public abstract class Enemy { }

    public class Asteroid : Enemy
    {
        private IMoveController _moveController;
        private IAction[] _onDestroyActions;
        private IHitDetector _hitDetector;
        private GroupType _groupType = GroupType.Enemy;
        public Asteroid(IMoveController moveController)
        {
            _moveController = moveController;
        }
    }

    public class Main
    {

    }
}