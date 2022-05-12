namespace Asteroids.GameLogic.Movers
{
    public class FollowMoveController : IMoveController
    {
        private readonly IFollowMover _mover;

        public FollowMoveController(IFollowMover mover)
        {
            _mover = mover;
        }

        public void Move()
        {
            _mover.Move();
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