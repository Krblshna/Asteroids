using UnityEngine;

namespace Asteroids.Asteroid
{
    public interface IDestroyAction
    {
        void Execute();
    }

    public class CreateAsteroid : MonoBehaviour, IDestroyAction
    {
        [SerializeField] private AsteroidType _asteroidType;
        [SerializeField] private float _creationRadius;
        [SerializeField] private int _amountMin, _amountMax;

        public void Execute()
        {
            var amount = Random.Range(_amountMin, _amountMax + 1);
            for (var i = 0; i < amount; i++)
            {
                var randX = RandVal();
                var randY = RandVal();
                var creationPos = (Vector2)transform.position + new Vector2(randX, randY);
                AsteroidsManager.Instance.CreateAsteroid(_asteroidType, creationPos);
            }
        }

        public float RandVal()
        {
            return Random.Range(-_creationRadius, _creationRadius);
        }
    }
}