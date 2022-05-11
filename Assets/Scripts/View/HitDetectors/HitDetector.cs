using System;
using Asteroids.Common;
using Asteroids.FriendlyFire;
using UnityEngine;

namespace Asteroids.HitDetectors
{
    public class HitDetector : MonoBehaviour, IHitDetector
    {
        private IFriendlyFireChecker _friendlyFireChecker;
        private Action<DamageType> _onHit;

        public void Init(GroupType groupType, Action<DamageType> onHit)
        {
            _friendlyFireChecker = new FriendlyFireChecker(groupType);
            _onHit = onHit;
        }

        public bool Hit(GroupType groupType, DamageType damageType = DamageType.Common)
        {
            if (_friendlyFireChecker.IsFriendly(groupType)) return false;
            _onHit?.Invoke(damageType);
            return true;
        }
    }
}