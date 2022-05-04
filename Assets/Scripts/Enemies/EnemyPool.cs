using Asteroids.Common;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Enemies
{
    [System.Serializable]
    public class EnemyPool : IEnemyPool
    {
        public EnemyType Type;
        public GameObject EffectGameObject;
        private ObjectPool<IEnemy> _pool;

        public void Init()
        {
            _pool = new ObjectPool<IEnemy>(CreateNewEnemy, OnGet, OnRelease);
        }

        public IEnemy Get()
        {
            return _pool.Get();
        }

        public IEnemy CreateNewEnemy()
        {
            var obj = Object.Instantiate(EffectGameObject, Vector3.zero, Quaternion.identity);
            var enemy = obj.GetComponent<IEnemy>();
            enemy.Init(_pool.Release);
            return enemy;
        }

        private void OnGet(IEnemy enemy)
        {
            enemy.SetActive(true);
            enemy.OnCreate();
        }

        private void OnRelease(IEnemy enemy)
        {
            enemy.SetActive(false);
        }
    }
}