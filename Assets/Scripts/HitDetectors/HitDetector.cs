using System;
using Asteroids.Common;
using Asteroids.FriendlyFire;
using UnityEngine;

namespace Asteroids.HitDetectors
{
    public class HitDetector : MonoBehaviour, IHitDetector
    {
        private IFriendlyFireChecker _friendlyFireChecker;
        private Action _onHit;

        public void Init(GroupType groupType, Action onHit)
        {
            _friendlyFireChecker = new FriendlyFireChecker(groupType);
            _onHit = onHit;
        }

        public bool Hit(GroupType groupType)
        {
            if (_friendlyFireChecker.IsFriendly(groupType)) return false;
            _onHit?.Invoke();
            return true;
        }
    }
}