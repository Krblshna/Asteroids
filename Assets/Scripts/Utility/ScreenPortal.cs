using UnityEngine;

namespace Asteroids.Utility
{
    public static class ScreenPortal
    {
        private static readonly float MinY;
        private static readonly float MaxY;
        private static readonly float MinX;
        private static readonly float MaxX;

        static ScreenPortal()
        {
            MinY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z)).y;
            MaxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -Camera.main.transform.position.z)).y;
            MinX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z)).x;
            MaxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -Camera.main.transform.position.z)).x;
        }

        static float ValidateCoordinate(float coordinateValue, float min, float max)
        {
            coordinateValue = coordinateValue > max ? min : coordinateValue;
            coordinateValue = coordinateValue < min ? max : coordinateValue;
            return coordinateValue;
        }

        public static Vector3 ValidatePos(Vector3 pos, float size)
        {
            var posX = ValidateCoordinate(pos.x, MinX - size / 2, MaxX + size / 2);
            var posY = ValidateCoordinate(pos.y, MinY - size / 2, MaxY + size / 2);
            return new Vector3(posX, posY, pos.z);
        }
    }
}