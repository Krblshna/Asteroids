using System;
using Asteroids.GameLogic.Common;
using UnityEngine;

namespace Asteroids.View.Weapon
{
    public interface IBullet
    {
        void SetActive(bool active);
        void Init(GroupType groupType, float speed, float lifeTime, Action<IBullet> onDestroyAction);
        void OnActivate(Vector2 initPos, Vector2 fireDirection);
    }
}