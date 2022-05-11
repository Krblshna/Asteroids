using Asteroids.Common;
using Asteroids.GameManagement;
using UnityEngine;

namespace Asteroids.Movers
{
    public class FollowMoveController : IMoveController
    {
        private readonly float _velocity;
        private readonly IFollowMover _mover;

        public FollowMoveController(IFollowMover mover, float velocity)
        {
            _mover = mover;
            _velocity = velocity;
        }

        public void Move()
        {
            var followable = GameManager.Instance.Player.GetComponent<IFollowable>();
            _mover.StartFollow(followable, _velocity);
        }

        public void DoOnDestroy()
        {
        }

        public void Update()
        {
            _mover.Update();
        }
    }
}