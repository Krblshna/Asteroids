using System;
using UnityEngine;

namespace Asteroids.Effect
{
    public class ParticleEffect : MonoBehaviour, IEffect
    {
        private ParticleSystem _particleSystem;
        public GameObject GetObj => gameObject;
        public Action<IEffect> _onDestroyAction;
        public void Init(Action<IEffect> onDestroyAction)
        {
            _onDestroyAction = onDestroyAction;
        }

        void OnParticleSystemStopped()
        {
            _onDestroyAction?.Invoke(this);
        }

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void ShowEffect()
        {
            _particleSystem.Play();
        }

    }
}