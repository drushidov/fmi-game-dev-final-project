using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public GameObject spawnPointsParent;
    public GameObject[] enemyVariants;
    public int enemiesPerWave;
    public float delayBeforeFirstWave;
    public float delayBetweenWaves;

    private int spawnPointsCount;
    private int wave;
    private int remainingEnemies;
    private List<GameObject> previousWaveEnemies;

    void Start()
    {
        spawnPointsCount = spawnPointsParent.transform.childCount;
        
        if (enemiesPerWave > spawnPointsCount)
        {
            enemiesPerWave = spawnPointsCount;
        }

        previousWaveEnemies = new List<GameObject>();
        wave = 1;
        Invoke("SpawnWave", delayBeforeFirstWave);
    }

    void SpawnWave()
    {
        // Pick enemy variant
        int enemyVariant = Random.Range(0, enemyVariants.Length);

        // Shuffle spawn positions
        int[] spawnPositionIndexes = new int[spawnPointsCount];

        for (int i = 0; i < spawnPointsCount; i++)
        {
            spawnPositionIndexes[i] = i;
        }

        int n = spawnPositionIndexes.Length;

        // Shuffle array
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            int temp = spawnPositionIndexes[n];
            spawnPositionIndexes[n] = spawnPositionIndexes[k];
            spawnPositionIndexes[k] = temp;
        }

        Transform enemySpawnPoint;
        GameObject spawnedEnemy;

        // Iterate through spawn positions and spawn enemies
        for (int i = 0; i < enemiesPerWave; i++)
        {
            enemySpawnPoint = spawnPointsParent.transform.GetChild(spawnPositionIndexes[i]);

            spawnedEnemy = Instantiate(enemyVariants[enemyVariant], enemySpawnPoint.position, Quaternion.identity);

            Vector3 enemyRotation = spawnedEnemy.transform.rotation.eulerAngles;
            enemyRotation.y = (enemyRotation.y + Random.Range(0f, 360f)) % 360f;

            spawnedEnemy.transform.eulerAngles = enemyRotation;

            spawnedEnemy.GetComponent<EnemyStats>().SetLevel(wave - 1);
            spawnedEnemy.GetComponent<EnemyHealth>().OnDeath += OnEnemyDeath;

            previousWaveEnemies.Add(spawnedEnemy);
        }

        remainingEnemies = enemiesPerWave;
        wave++;
    }

    void OnEnemyDeath()
    {
        remainingEnemies--;

        if (remainingEnemies == 0)
        {
            Debug.Log("Enemies cleared");

            // Show enemies cleared UI

            Invoke("ClearPreviousWaveEnemies", delayBetweenWaves / 2.0f);
            Invoke("SpawnWave", delayBetweenWaves);
        }
    }

    void ClearPreviousWaveEnemies()
    {
        if (previousWaveEnemies.Count > 0)
        {
            foreach (GameObject enemy in previousWaveEnemies)
            {
                Destroy(enemy);
            }
        }

        previousWaveEnemies.Clear();
    }
}
