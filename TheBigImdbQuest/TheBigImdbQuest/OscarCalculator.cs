﻿using System.Collections.Generic;

namespace TheBigImdbQuest
{
    public static class OscarCalculator
    {
        private static readonly Dictionary<int, double> oscrarRewards = new Dictionary<int, double>
        {
            {  0, 0.0 },
            {  1, 0.3 },
            {  2, 0.3 },
            {  3, 0.5 },
            {  4, 0.5 },
            {  5, 0.5 },
            {  6, 1.0 },
            {  7, 1.0 },
            {  8, 1.0 },
            {  9, 1.0 },
            { 10, 1.0 },
        };

        public static double GetOscarRewards(int nrOfOscars)
        {
            return oscrarRewards.TryGetValue(nrOfOscars, out double reward) ? reward : 1.5;
        }
    }
}
