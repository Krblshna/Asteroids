using Asteroids.Common;
using Asteroids.GameManagement;
using UnityEngine;

namespace Asteroids.Enemies
{
    public class EnemyStartSpawner : MonoBehaviour
    {
        private int _minAsteroids = 3, _maxAsteroids = 5;
        private IEnemyCreator _enemyCreator;

        void Awake()
        {
            _enemyCreator = GetComponent<IEnemyCreator>();
        }

        private void Start()
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            var asteroidsAmount = Random.Range(_minAsteroids, _maxAsteroids + 1);
            for (var i = 0; i < asteroidsAmount; i++)
            {
                _enemyCreator.Create(EnemyType.asteroid, GameManager.Instance.GetPosFromPlayer());
            }
        }
    }
}