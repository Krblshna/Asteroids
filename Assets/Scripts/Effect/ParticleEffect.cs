using UnityEngine;

namespace Asteroids.Effect
{
    public class ParticleEffect : MonoBehaviour, IEffect
    {
        private ParticleSystem _particle;
        public void ShowEffect()
        {
            _particle.Play();
        }
    }
}