namespace Asteroids.GameLogic.Weapon
{
    public interface ILaserData
    {
        int Ammo { get; }
        float LaserCooldown { get; }
    }
}