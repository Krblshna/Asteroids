using Asteroids.GameLogic.Common;

namespace Asteroids.GameLogic.Player
{
    public interface IInput
    {
        bool Left { get;  }
        bool Right { get;  }
        bool Up { get;  }
        bool Fire { get; }
        bool IsFire(FireType fireType);
        void CustomUpdate();
        void OnDestroy();
    }
}