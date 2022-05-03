using UnityEngine;

namespace Asteroids.Utility
{
    //FIXME change name
    public static class ScreenPortal
    {
        private static readonly float MinY;
        private static readonly float MaxY;
        private static readonly float MinX;
        private static readonly float MaxX;

        static ScreenPortal()
        {
            var camera = Camera.main;
            MinY = camera.ScreenToWorldPoint(new Vector3(0, 0, -camera.transform.position.z)).y;
            MaxY = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, -camera.transform.position.z)).y;
            MinX = camera.ScreenToWorldPoint(new Vector3(0, 0, -camera.transform.position.z)).x;
            MaxX = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, -camera.transform.position.z)).x;
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

        public static Vector2 GetRandPos()
        {
            var randX = Random.Range(MinX, MaxX);
            var randY = Random.Range(MinY, MaxY);
            return new Vector2(randX, randY);
        }
    }
}