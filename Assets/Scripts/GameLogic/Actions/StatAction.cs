using Asteroids.Common;
using Asteroids.Statistics;
using UnityEngine;

namespace Asteroids.Actions
{
    public class StatAction : IAction
    {
        private readonly StatType _statEvent;
        private readonly IGamePoints _gamePoints;

        public StatAction(IGamePoints gamePoints, StatType statEvent)
        {
            _gamePoints = gamePoints;
            _statEvent = statEvent;
        }

        public void Call()
        {
            _gamePoints.TriggerStatEvent(_statEvent);
        }
    }
}