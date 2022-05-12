using System;
using Asteroids.GameLogic.Providers;
using Asteroids.GameLogic.Utility;
using UnityEngine;

namespace Asteroids.GameLogic.PositionValidators
{
    public class AvoidTransform : IPositionValidator
    {
        private readonly IPosProvider _positionProvider;
        private int _maxRandTries = 30;
        public AvoidTransform(IPosProvider positionProvider)
        {
            _positionProvider = positionProvider;
        }

        public Vector3 GetPos()
        {
            Vector3 pos = _positionProvider.GetPos;
            Vector3 randPos;
            bool intersect;
            var counter = 0;
            do
            {
                randPos = ScreenData.GetRandPos();
                intersect = Vector2.Distance(pos, randPos) < 3f;
                counter++;
                if (counter > _maxRandTries) throw new Exception("can't find rand space");
            } while (intersect);
            return randPos;
        }
    }
}