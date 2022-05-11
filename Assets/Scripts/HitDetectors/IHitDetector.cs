using System;
using System.Collections.Generic;
using Asteroids.Common;

namespace Asteroids.HitDetectors
{
    public interface IHitDetector
    {
        void Init(GroupType groupType, Action<DamageType> onHit);
        bool Hit(GroupType groupType, DamageType damageType = DamageType.Common);
    }
}