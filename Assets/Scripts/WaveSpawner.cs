using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    private static int waveNumber;
    public Wave[] waves = new Wave[waveNumber];

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 10f;
    public Text wavecountdownText;

    public GameManager gameManager;

    private int waveIndex = 0;

    [Header("Wave Controller")]
    public List<GameObject> enemyList = new List<GameObject>();
    public int minWaves = 1;
    public int maxWaves = 10;
    public int minEnemiesCount = 1;
    public int maxEnemiesCount = 10;
    public float minRate = 1;
    public float maxRate = 4;

   private void Start()
    {
        EnemiesAlive = 0;
        setWaves();
    }

    private void Update()
    {
        if (EnemiesAlive > 0) {
            return;
        }
        
        if (waveIndex == waveNumber && PlayerStats.Lives > 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        wavecountdownText.text = string.Format("{0:00.00}", countdown);
    }

    void setWaves() {
        
        waveNumber = Random.Range(minWaves, maxWaves + 1);
        int enemySize = enemyList.Count;
        
        for (int i = 0; i < waveNumber; i++)
        {
            int enemyType = Random.Range(0, enemySize);
            int enemiesCount = Random.Range(minEnemiesCount, maxEnemiesCount + 1);
            float waveRate = Random.Range(minRate, maxRate + 1f);

            waves[i].enemy = enemyList[enemyType];
            waves[i].count = enemiesCount;
            waves[i].rate = waveRate;
        }
       }

    IEnumerator SpawnWave() {

        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
    }
}
