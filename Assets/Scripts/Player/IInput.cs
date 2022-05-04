namespace Asteroids.Player
{
    public interface IInput
    {
        bool Left { get;  }
        bool Right { get;  }
        bool Up { get;  }
        bool Fire { get; }
        bool AltFire { get; }
        void CustomUpdate();
    }
}