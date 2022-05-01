using System;
using UnityEngine;

namespace Asteroids.Weapon
{
    public interface IBullet
    {
        void SetActive(bool active);
        void Init(float bulletSpeed, float lifeTime, Action<IBullet> onDestroyAction);
        void OnActivate(Vector2 initPos, Vector2 fireDirection);
    }
}