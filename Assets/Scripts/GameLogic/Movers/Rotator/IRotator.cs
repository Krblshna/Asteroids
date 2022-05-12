namespace Asteroids.GameLogic.Movers
{
    public interface IRotator
    {
        void Rotate(float angularVelocity);
        void DoOnDestroy();
        void Update();
    }
}