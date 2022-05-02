using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Asteroid
{

    [System.Serializable]
    public class AsteroidPool : IAsteroidPool
    {
        public AsteroidType Type;
        public GameObject EffectGameObject;
        private ObjectPool<IAsteroid> _pool;

        public void Init()
        {
            _pool = new ObjectPool<IAsteroid>(CreateNewAsteroid, OnGet, OnRelease);
        }

        public IAsteroid Get()
        {
            return _pool.Get();
        }

        public IAsteroid CreateNewAsteroid()
        {
            var obj = Object.Instantiate(EffectGameObject, Vector3.zero, Quaternion.identity);
            var asteroid = obj.GetComponent<IAsteroid>();
            asteroid.Init(_pool.Release);
            return asteroid;
        }

        private void OnGet(IAsteroid asteroid)
        {
            asteroid.SetActive(true);
            asteroid.OnGet();
        }

        private void OnRelease(IAsteroid asteroid)
        {
            asteroid.SetActive(false);
        }
    }
}