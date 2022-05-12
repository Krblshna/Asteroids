using Asteroids.GameLogic;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.PositionValidators;
using UnityEngine;

namespace Asteroids.View.Enemies
{
    public class EnemyTimeSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnParams[] spawnParams;
        private IEnemyCreator _enemyCreator;
        private IPositionValidator _positionValidator;

        void Awake()
        {
            _enemyCreator = GetComponent<IEnemyCreator>();
            _positionValidator = new AvoidTransform(Logic.PlayerPosProvider);
        }

        void Start()
        {
            foreach (var spawnParam in spawnParams)
            {
                spawnParam.Init(Spawn);
            }
        }

        void Update()
        {
            foreach (var spawnParam in spawnParams)
            {
                spawnParam.TrySpawn();
            }
        }

        private void Spawn(EnemyType enemyType)
        {
            _enemyCreator.Create(enemyType, _positionValidator.GetPos());
        }
    }
}