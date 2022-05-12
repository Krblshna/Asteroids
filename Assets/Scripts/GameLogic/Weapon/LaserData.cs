namespace Asteroids.GameLogic.Weapon
{
    public class LaserData
    {
        public int MaxAmmo { get; }
        public float AmmoRecoveryTime { get; }
        public float FireDelay { get; }
        public float LaserLifeTime { get; }

        public LaserData(int maxAmmo,
            float ammoRecoveryTime,
            float fireDelay,
            float laserLifeTime)
        {
            MaxAmmo = maxAmmo;
            AmmoRecoveryTime = ammoRecoveryTime;
            FireDelay = fireDelay;
            LaserLifeTime = laserLifeTime;
        }
    }
}