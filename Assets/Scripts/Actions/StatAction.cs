using Asteroids.Common;
using Asteroids.Statistics;
using UnityEngine;

namespace Asteroids.Actions
{
    public class StatAction : MonoBehaviour, IAction
    {
        [SerializeField] private StatType _statEvent;

        public void Call()
        {
            GamePoints.TriggerStatEvent(_statEvent);
        }
    }
}