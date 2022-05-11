using UnityEngine;

namespace Asteroids.Movers
{
    public class SimpleMoveController : IMoveController
    {
        private readonly SimpleMoveData _moveData;
        private readonly IMover _mover;
        private readonly IRotator _rotator;

        private bool _active;

        public SimpleMoveController(IMover mover, IRotator rotator, SimpleMoveData moveData)
        {
            _mover = mover;
            _rotator = rotator;
            _moveData = moveData;
        }

        public void Update()
        {
            if (!_active) return;
            _mover.Update();
            _rotator.Update();
        }

        int RandSign()
        {
            return (int)Mathf.Sign(Random.Range(-1, 1));
        }

        public void Move()
        {
            _active = true;
            var randomVelocityVector = new Vector2(RandVelocity(), RandVelocity());
            var randomRotation = RandSign() * Random.Range(_moveData.MinRotation, _moveData.MaxRotation);
            _mover.Move(randomVelocityVector.normalized, randomVelocityVector.sqrMagnitude);
            _rotator.Rotate(randomRotation);
        }

        private float RandVelocity()
        {
            return RandSign() * Random.Range(_moveData.MinStartVelocity, _moveData.MaxStartVelocity);
        }

        public void DoOnDestroy()
        {
            _mover.DoOnDestroy();
            _rotator.DoOnDestroy();
            _active = false;
        }
    }
}