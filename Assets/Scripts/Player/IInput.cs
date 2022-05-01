namespace Asteroids.Player
{
    public interface IInput
    {
        bool Left { get;  }
        bool Right { get;  }
        bool Up { get;  }
        bool Down { get;  }
        float Horizontal { get; }
        bool Fire { get; }
        void CustomUpdate();
    }
}