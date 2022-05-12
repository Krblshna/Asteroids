using Asteroids.GameLogic.Common;
using Asteroids.View.Enemies;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.View.Pool
{
    [System.Serializable]
    public class EnemyPool : IEnemyPool
    {
        public EnemyType Type;
        public GameObject EffectGameObject;
        private ObjectPool<IEnemyView> _pool;

        public void Init()
        {
            _pool = new ObjectPool<IEnemyView>(CreateNewEnemy, OnGet, OnRelease);
        }

        public IEnemyView Get()
        {
            return _pool.Get();
        }

        public IEnemyView CreateNewEnemy()
        {
            var obj = Object.Instantiate(EffectGameObject, Vector3.zero, Quaternion.identity);
            var enemy = obj.GetComponent<IEnemyView>();
            enemy.Init(_pool.Release);
            return enemy;
        }

        private void OnGet(IEnemyView enemyView)
        {
            enemyView.SetActive(true);
            enemyView.OnCreate();
        }

        private void OnRelease(IEnemyView enemyView)
        {
            enemyView.SetActive(false);
        }
    }
}