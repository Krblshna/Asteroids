using Asteroids.Common;
using Asteroids.Enemies;
using UnityEngine;

namespace Asteroids.Actions
{
    public class CreateEnemyAction : MonoBehaviour, IAction
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private float _creationRadius;
        [SerializeField] private int _amountMin, _amountMax;

        public void Call()
        {
            var amount = Random.Range(_amountMin, _amountMax + 1);
            for (var i = 0; i < amount; i++)
            {
                var randX = RandVal();
                var randY = RandVal();
                var creationPos = (Vector2)transform.position + new Vector2(randX, randY);
                EnemiesManager.Instance.CreateEnemy(_enemyType, creationPos);
            }
        }

        public float RandVal()
        {
            return Random.Range(-_creationRadius, _creationRadius);
        }
    }
}