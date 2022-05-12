using Asteroids.GameLogic;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.PositionValidators;
using UnityEngine;

namespace Asteroids.View.Enemies
{
    public class EnemyStartSpawner : MonoBehaviour
    {
        [SerializeField]
        private int _minAsteroids = 3, _maxAsteroids = 5;
        private IEnemyCreator _enemyCreator;
        private IPositionValidator _positionValidator;

        void Awake()
        {
            _enemyCreator = GetComponent<IEnemyCreator>();
            _positionValidator = new AvoidTransform(Logic.PlayerPosProvider);
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
                _enemyCreator.Create(EnemyType.asteroid, _positionValidator.GetPos());
            }
        }
    }
}