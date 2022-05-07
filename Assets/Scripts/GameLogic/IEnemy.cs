using Asteroids.Common;

namespace Asteroids.GameLogic
{
    public interface IEnemy
    {
        GroupType GroupType { get; }
        void OnCreate();
        void OnDestroy();
        void Update();
    }
}