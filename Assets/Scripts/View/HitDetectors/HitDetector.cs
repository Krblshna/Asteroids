using System;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.FriendlyFire;
using UnityEngine;

namespace Asteroids.View.HitDetectors
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