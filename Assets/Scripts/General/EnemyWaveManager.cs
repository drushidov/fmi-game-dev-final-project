using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public GameObject spawnPointsParent;
    public GameObject[] enemyVariants;
    public int enemiesPerWave;
    public float delayBeforeFirstWave;
    public float delayBetweenWaves;

    public TextMeshProUGUI waveText;

    private int spawnPointsCount;
    private int wave;
    private int bestWaveCount;
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
        wave = 0;
        Invoke("ShowNextWaveMessage", delayBeforeFirstWave / 2.0f);
        Invoke("SpawnWave", delayBeforeFirstWave);
    }

    void SpawnWave()
    {
        wave++;

        if (wave > bestWaveCount)
        {
            bestWaveCount = wave;
        }

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

        HideWaveMessages();
    }

    void OnEnemyDeath()
    {
        remainingEnemies--;

        if (remainingEnemies == 0)
        {
            StartCoroutine(ShowWaveMessages());

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

    public int GetWave()
    {
        return wave;
    }

    public int GetBestWaveCount()
    {
        return bestWaveCount;
    }

    public void SetBestWaveCount(int count)
    {
        bestWaveCount = count;
    }

    private void ShowNextWaveMessage()
    {
        waveText.text = "Wave " + (wave + 1);
        waveText.gameObject.SetActive(true);
    }

    IEnumerator ShowWaveMessages()
    {
        waveText.text = "Wave " + wave + " cleared";
        waveText.gameObject.SetActive(true);

        yield return new WaitForSeconds(delayBetweenWaves / 2.0f);

        ShowNextWaveMessage();
    }

    private void HideWaveMessages()
    {
        waveText.gameObject.SetActive(false);
    }
}
