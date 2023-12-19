using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyScaling : MonoBehaviour
    {
        // Amount of points per enemy type
        // Tier 1 0b00000011
        // Tier 2 0b00001100
        // Tier 3 0b00110000
        // Tier 4 0b11000000
        private readonly Dictionary<int, int> enemyPoints = new Dictionary<int, int>
        {
            // Tier 1
            { 1, 1 },
            { 2, 2 },
            { 3, 4 },
            // Tier 2
            { 4, 6 },
            { 8, 8 },
            { 12, 12 },
            // Tier 3
            { 16, 16 },
            { 32, 20 },
            { 48, 25 },
            // Tier 4
            { 64, 30 },
            { 128, 36 },
            { 172, 45 }
        };

        
		public int type1chance = 8;
		public int type2chance = 5;
		public int type3chance = 2;

        public ulong getEnemies(int enemyTier, int pointAmount)
        {
            var totalOdds = type1chance + type2chance + type3chance;
            // output is in form 0x0000ffff0000ffff
            ulong output = 0;
            while (pointAmount >= enemyPoints[1 << ((enemyTier - 1) * 2)])
            {
                var randomInt = UnityEngine.Random.Range(0, totalOdds);
                int enemyType;
                if (randomInt < type1chance)
                {
                    enemyType = 1;
                } else if (randomInt < (type1chance + type2chance))
                {
                    enemyType = 2;
                } else
                {
                    enemyType = 3;
                }
                
                var points = enemyPoints[enemyType << ((enemyTier - 1) * 2)];
                if (points > pointAmount)
                {
                    continue;
                }
                pointAmount -= points;
                output = (output + ((ulong)1 << ((enemyType - 1) * 16)));
            }
            return output;
        }
    }
}
