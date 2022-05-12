using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Statistics;

namespace Asteroids.GameLogic.Actions
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