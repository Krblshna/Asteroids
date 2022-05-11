using Asteroids.Common;

namespace Asteroids.Player
{
    public interface IInput
    {
        bool Left { get;  }
        bool Right { get;  }
        bool Up { get;  }
        bool IsFire(FireType fireType);
        void CustomUpdate();
        void OnDestroy();
    }
}