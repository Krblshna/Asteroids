using Asteroids.Effect;
using UnityEngine;

namespace Asteroids.Actions
{
    public class ParticleAction : MonoBehaviour, IAction
    {
        [SerializeField] private EffectType _destroyEffect;

        public void Call()
        {
            Debug.Log("Call particle");
            EffectsManager.Instance.CreateEffect(_destroyEffect, transform.position);
        }
    }
}