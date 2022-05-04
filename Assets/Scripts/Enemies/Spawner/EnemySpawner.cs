using Asteroids.Common;
using Asteroids.GameManagement;
using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private SpawnParams[] spawnParams;
        private bool _active;


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
            EnemiesManager.Instance.CreateEnemy(enemyType, GameManager.Instance.GetPosFromPlayer());
        }
    }
}