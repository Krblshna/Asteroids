using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.PositionValidators
{
    public class BorderValidator : IBorderValidator
    {
        private readonly float _bodySize;

        public BorderValidator(float bodySize)
        {
            _bodySize = bodySize;
        }
        private float ValidateCoordinate(float coordinateValue, float min, float max)
        {
            coordinateValue = coordinateValue > max ? min : coordinateValue;
            coordinateValue = coordinateValue < min ? max : coordinateValue;
            return coordinateValue;
        }

        public Vector3 Validate(Vector3 pos)
        {
            var posX = ValidateCoordinate(pos.x, ScreenData.MinX - _bodySize / 2, ScreenData.MaxX + _bodySize / 2);
            var posY = ValidateCoordinate(pos.y, ScreenData.MinY - _bodySize / 2, ScreenData.MaxY + _bodySize / 2);
            return new Vector3(posX, posY, pos.z);
        }
    }
}