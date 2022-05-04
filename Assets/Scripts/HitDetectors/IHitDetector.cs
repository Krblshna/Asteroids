using System;
using Asteroids.Common;

namespace Asteroids.HitDetectors
{
    public interface IHitDetector
    {
        void Init(GroupType groupType, Action onHit);
        bool Hit(GroupType groupType);
    }
}