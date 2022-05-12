using System;

namespace Asteroids.View.Player
{
    public interface IPlayerView
    {
        void Init(Action onDestroy);
    }
}