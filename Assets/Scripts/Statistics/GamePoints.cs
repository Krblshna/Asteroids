﻿using System.Collections.Generic;
using Asteroids.Utility;
using UnityEngine;
using System;
using Asteroids.Common;

namespace Asteroids.Statistics
{
    public class GamePoints : IPlayerStat
    {
        public int StatAmount { get; private set; }
        private readonly Dictionary<StatType, int> _statTable = new Dictionary<StatType, int>()
        {
            {StatType.DestroyAsteroid, 10},
            {StatType.DestroyAsteroidFragment, 5},
            {StatType.DestroyUfo, 15}
        };

        public void TriggerStatEvent(StatType statType)
        {
            if (!_statTable.TryGetValue(statType, out var value)) return;
            StatAmount += value;
        }

        public void Clear()
        {
            StatAmount = 0;
        }
    }
}