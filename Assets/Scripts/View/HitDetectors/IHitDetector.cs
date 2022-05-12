using System;
using Asteroids.GameLogic.Common;

namespace Asteroids.View.HitDetectors
{
    public interface IHitDetector
    {
        void Init(GroupType groupType, Action<DamageType> onHit);
        bool Hit(GroupType groupType, DamageType damageType = DamageType.Common);
    }
}