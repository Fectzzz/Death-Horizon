using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int noOfEnemies;

    public GameObject[] typeOfEnemies;
    public float spawnInterval;
    public bool potionSpawn;
    public bool coinSpawn = true;
}

public class WaveEnnemy : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public Animator animator;

    public TextMeshProUGUI waveName;
    private Wave currentWave;

    public GameObject potionPrefabs;
    public GameObject coinPrefab;

    public int currentWaveNumber;
    private float nextSpawnTime;
    public float radius;
    private bool canSpawn = true;
    private bool canAnimate = false;

    private void Update()
    {
        currentWave = waves[currentWaveNumber];

        SpawnWave();

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Ennemi");

        if (totalEnemies.Length == 0)
        {
            if (currentWaveNumber + 1 != waves.Length)
            {
                if (canAnimate)
                {
                    waveName.text = waves[currentWaveNumber + 1].waveName;

                    animator.SetTrigger("WaveComplete");

                    canAnimate = false;
                }
            }
            else
            {
                Debug.Log("Finish!");
            }
        }
    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.noOfEnemies--;

            nextSpawnTime = Time.time + currentWave.spawnInterval;

            if (currentWave.noOfEnemies == 0)
            {
                canSpawn = false;
                canAnimate = true;
                
                if(currentWave.potionSpawn == true)
                {
                    var position = new Vector2(Random.Range(-1123, -1108), -540);
                    Instantiate(potionPrefabs, position, Quaternion.identity);
                }
                
                if(currentWave.coinSpawn == true)
                {
                    var position = new Vector2(Random.Range(-1123, -1108), -540);
                    Instantiate(coinPrefab, position, Quaternion.identity);
                }
            }
        }
    }
}