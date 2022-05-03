using System.Collections.Generic;
using Asteroids.Utility;
using UnityEngine;
using System;

namespace Asteroids.Statistics
{
    public enum StatEvent { DestroyAsteroid, DestroyAsteroidFragment, DestroyUfo}

    public class Stats : Singleton<Stats>
    {
        public int StatAmount { get; private set; }
        public event Action OnStatChange;
        Dictionary<StatEvent, int> statTable = new Dictionary<StatEvent, int>()
        {
            {StatEvent.DestroyAsteroid, 10},
            {StatEvent.DestroyAsteroidFragment, 5},
            {StatEvent.DestroyUfo, 15}
        };

        public void OnAction(StatEvent eventType)
        {
            if (!statTable.TryGetValue(eventType, out var value)) return;
            StatAmount += value;
        }

        public void Clear()
        {
            StatAmount = 0;
        }
    }
}