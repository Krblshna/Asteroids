using Asteroids.Common;
using Asteroids.Statistics;
using UnityEngine;

namespace Asteroids.Actions
{
    public class StatAction : IAction
    {
        private readonly StatType _statEvent;
        private readonly IPlayerStat _playerStat;

        public StatAction(IPlayerStat playerStat, StatType statEvent)
        {
            _playerStat = playerStat;
            _statEvent = statEvent;
        }

        public void Call()
        {
            _playerStat.TriggerStatEvent(_statEvent);
        }
    }
}