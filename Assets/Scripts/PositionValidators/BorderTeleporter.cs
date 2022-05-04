using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.PositionValidators
{
    public class BorderTeleporter : MonoBehaviour
    {
        [SerializeField] private float _bodySize = 1f;

        public void Update()
        {
            transform.position = ValidatePos();
        }

        static float ValidateCoordinate(float coordinateValue, float min, float max)
        {
            coordinateValue = coordinateValue > max ? min : coordinateValue;
            coordinateValue = coordinateValue < min ? max : coordinateValue;
            return coordinateValue;
        }

        public Vector3 ValidatePos()
        {
            var pos = transform.position;
            var posX = ValidateCoordinate(pos.x, ScreenData.MinX - _bodySize / 2, ScreenData.MaxX + _bodySize / 2);
            var posY = ValidateCoordinate(pos.y, ScreenData.MinY - _bodySize / 2, ScreenData.MaxY + _bodySize / 2);
            return new Vector3(posX, posY, pos.z);
        }
    }
}