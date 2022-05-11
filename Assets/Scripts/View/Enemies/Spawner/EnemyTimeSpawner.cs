using Asteroids.Common;
using Asteroids.GameManagement;
using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.Enemies
{
    public class EnemyTimeSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnParams[] spawnParams;
        private IEnemyCreator _enemyCreator;

        void Awake()
        {
            _enemyCreator = GetComponent<IEnemyCreator>();
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

        //FIXME
        private void Spawn(EnemyType enemyType)
        {
            _enemyCreator.Create(enemyType, GameManager.Instance.GetPosFromPlayer());
        }
    }
}