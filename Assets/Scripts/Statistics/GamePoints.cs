using System.Collections.Generic;
using Asteroids.Utility;
using UnityEngine;
using System;
using Asteroids.Common;

namespace Asteroids.Statistics
{
    

    public static class GamePoints
    {
        public static int StatAmount { get; private set; }
        private static readonly Dictionary<StatType, int> _statTable = new Dictionary<StatType, int>()
        {
            {StatType.DestroyAsteroid, 10},
            {StatType.DestroyAsteroidFragment, 5},
            {StatType.DestroyUfo, 15}
        };

        public static void TriggerStatEvent(StatType statType)
        {
            if (!_statTable.TryGetValue(statType, out var value)) return;
            StatAmount += value;
        }

        public static void Clear()
        {
            StatAmount = 0;
        }
    }
}