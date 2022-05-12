namespace Asteroids.GameLogic.Movers
{
    public interface IMoveController
    {
        void Move();
        void DoOnDestroy();
        void Update();
    }
}