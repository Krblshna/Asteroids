using Asteroids.GameLogic.Common;

namespace Asteroids.GameLogic.Enemies
{
    public interface IEnemy
    {
        GroupType GroupType { get; }
        void OnCreate();
        void OnDestroy();
        void Update();
    }
}