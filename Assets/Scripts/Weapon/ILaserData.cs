namespace Asteroids.Weapon
{
    public interface ILaserData
    {
        int Ammo { get; }
        float LaserCooldown { get; }
    }
}