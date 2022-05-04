using UnityEngine;

namespace Asteroids.Movers
{
    public class SimpleMoveController : MonoBehaviour, IMoveController
    {
        [SerializeField]
        private float _minStartForce,
            _maxStartForce,
            _minRotation,
            _maxRotation;
        private IMover _mover;
        int RandSign()
        {
            return (int)Mathf.Sign(Random.Range(-1, 1));
        }

        public void Move()
        {
            _mover = GetComponent<IMover>();
            var randomForce = new Vector2(RandSign() * Random.Range(_minStartForce, _maxStartForce), RandSign() * Random.Range(_minStartForce, _maxStartForce));
            var randomRotation = RandSign() * Random.Range(_minRotation, _maxRotation);
            _mover.Move(randomForce.normalized, randomForce.sqrMagnitude);
            _mover.Rotate(randomRotation);
        }

        public void DoOnDestroy()
        {
            _mover.DoOnDestroy();
        }
    }
}