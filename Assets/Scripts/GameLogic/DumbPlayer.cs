using Asteroids.Common;
using UnityEngine;

namespace Asteroids.GameLogic
{
    public class DumbPlayer : IFollowable
    {
        public Vector3 GetPos()
        {
            throw new System.NotImplementedException();
        }

        public bool Active { get; }
    }
}