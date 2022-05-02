using System.Collections.Generic;
using System.Linq;
using Asteroids.Effect;
using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.Asteroid
{
    public enum AsteroidType { mini, middle, big}
    public class AsteroidsManager : Singleton<AsteroidsManager>
    {
        [SerializeField] private AsteroidPool[] _pools;
        private Dictionary<AsteroidType, IAsteroidPool> _poolsDict;

        public override void Awake()
        {
            base.Awake();
            foreach (var effectPool in _pools)
            {
                effectPool.Init();
            }
            _poolsDict = _pools.ToDictionary(pool => pool.Type, pool => (IAsteroidPool)pool);
        }

        public void CreateAsteroid(AsteroidType asteroidType, Vector2 pos)
        {
            if (_poolsDict.TryGetValue(asteroidType, out var asteroidPool))
            {
                var asteroid = asteroidPool.Get();
                var asteroidObj = asteroid.GetObj;
                asteroidObj.transform.position = pos;
            }
        }
    }
}