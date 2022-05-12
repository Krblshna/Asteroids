using Asteroids.GameLogic.Common;
using Asteroids.View.Effect;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.View.Pool
{
    [System.Serializable]
    public class EffectPool : IEffectPool
    {
        public EffectType Type;
        public GameObject EffectGameObject;
        private ObjectPool<IEffect> _pool;

        public void Init()
        {
            _pool = new ObjectPool<IEffect>(CreateNewEffect, OnGet, OnRelease);
        }

        public IEffect GetEffect()
        {
            return _pool.Get();
        }

        public IEffect CreateNewEffect()
        {
            var obj = Object.Instantiate(EffectGameObject, Vector3.zero, Quaternion.identity);
            var effect = obj.GetComponent<IEffect>();
            effect.Init(_pool.Release);
            return effect;
        }

        private void OnGet(IEffect effect)
        {
            effect.SetActive(true);
        }

        private void OnRelease(IEffect effect)
        {
            effect.SetActive(false);
        }
    }
}