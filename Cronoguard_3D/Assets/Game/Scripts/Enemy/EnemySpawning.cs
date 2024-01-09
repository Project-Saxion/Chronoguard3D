using System;
using UnityEngine;


namespace Game.Scripts.Enemy
{
    public class EnemySpawning : MonoBehaviour
    {
        public GameObject parentObject;
        public GameObject[] enemies;
        private EnemyScaling enemyScaling;
        public uint radius = 5;
        public int numberOfPoints = 10000;
        private Vector3[] spawnLocations;
        public int healthEnemy = 10;
        public float scalingPercentage = 1.2f;
        public int setValueScaling = 50;
        public int startPointAmount = 100;
        public int enemySpawnHeight = 1;
        public int currentWave = 1;
    
        public void spawnWave(int wave)
        {
            int enemyTier;
            if (wave < 24)
            {
                enemyTier = Mathf.FloorToInt(wave / 8) + 1;
                Debug.Log(enemyTier);
            }
            else
            {
                enemyTier = 4;
            }

            int pointAmount = (int)Math.Floor((startPointAmount * (scalingPercentage * enemyTier)) + (setValueScaling * wave));
            spawnEnemies(enemyTier, pointAmount);

            currentWave += 1;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            spawnLocations = new Vector3[numberOfPoints];
            float angleStep = 360.0f / numberOfPoints;
            for (int i = 0; i < numberOfPoints; i++)
            {
                float angleInRadians = Mathf.Deg2Rad * (angleStep * i);
                float x = Mathf.Cos(angleInRadians) * radius;
                float z = Mathf.Sin(angleInRadians) * radius;
                spawnLocations[i] = new Vector3(x, enemySpawnHeight, z);
            } 
            
            enemyScaling = GetComponent<EnemyScaling>();
            spawnWave(currentWave);
        }
        
        private void spawnEnemies(int enemyTier, int pointAmount)
        {
            ulong enemyCount = enemyScaling.getEnemies(enemyTier, pointAmount);
            
            for (int i = 0; i < 3; i++)
            {
                ulong amountType = (enemyCount >> (i * 16)) & 0xffff;
                for (ulong j = 0; j < amountType; j++)
                {
                    int temp = UnityEngine.Random.Range(0, numberOfPoints);
                    Vector3 spawnLocation = spawnLocations[temp];
                    GameObject spawnEnemy = Instantiate(enemies[i], spawnLocation, parentObject.transform.rotation, parentObject.transform);
                    // spawnEnemy.GetComponent<HealthController>().setHealth(healthEnemy);
                }
            }
        }
    }
}
