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
        public int enemySpawnHeight = 10;
        public int currentWave = 1;
        private int enemiesLeft = 0;
        private SavingGame savingGame;
        private void Update()
        {
            if (enemiesLeft == 0)
            {
                spawnWave(currentWave);
                savingGame.DeleteGame("save");
                savingGame.SaveGame("save");
            }
        }
        
        public void spawnWave(int wave)
        {
            int enemyTier;
            if (wave < 24)
            {
                enemyTier = Mathf.FloorToInt(wave / 8) + 1;
            }
            else
            {
                enemyTier = 4;
            }

            int pointAmount = (int)Math.Floor((startPointAmount * (scalingPercentage * enemyTier)) + (setValueScaling * wave));
            Debug.Log(pointAmount);
            spawnEnemies(enemyTier, pointAmount);

            currentWave += 1;
        }

        public void DestroyEnemy()
        {
            enemiesLeft--;
        }

        // Start is called before the first frame update
        void Start()
        {
            spawnLocations = new Vector3[numberOfPoints];
            float angleStep = 360.0f / numberOfPoints;
            GameObject mainTarget = GameObject.FindGameObjectWithTag("Base");
            Vector3 locationMainTarget = mainTarget.transform.position;
            for (int i = 0; i < numberOfPoints; i++)
            {
                float angleInRadians = Mathf.Deg2Rad * (angleStep * i);
                float x = (Mathf.Cos(angleInRadians) * radius) + locationMainTarget.x;
                float z = (Mathf.Sin(angleInRadians) * radius) + locationMainTarget.z;
                spawnLocations[i] = new Vector3(x, enemySpawnHeight, z);
            }

            savingGame = GetComponent<SavingGame>();
            enemyScaling = GetComponent<EnemyScaling>();
            // spawnWave(currentWave);
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
                    enemiesLeft++;
                    spawnEnemy.transform.GetChild(enemyTier - 1).gameObject.SetActive(true);
                    // spawnEnemy.GetComponent<HealthController>().SetHealth(healthEnemy);
                }
            }
        }
    }
}
