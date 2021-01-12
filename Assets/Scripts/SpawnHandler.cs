using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnHandler : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerUpPrefabs;
    public TextMeshProUGUI ememiesLeftText;

    private int enemyCount;
    private int currentLevel = 1;
    private bool skipLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        NewWave(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyHandler>().Length;
        ememiesLeftText.text = "Enemies Left: " + enemyCount;
        if (enemyCount == 0 || skipLevel)
        {
            currentLevel++;
            NewWave(currentLevel);
        }
    }

    void NewWave(int waveCount)
    {
        for (int i = 0; i < waveCount; i++)
        {
            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(enemy,GenerateSpawn(10, 0),enemy.transform.rotation);
            GameObject powerup = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];
            Instantiate(powerup, GenerateSpawn(10, powerup.GetComponent<BoxCollider>().size.y/2 + 1f), powerup.transform.rotation);
        }
    }

    Vector3 GenerateSpawn(float range, float y)
    {
        float spawnX = Random.Range(-range, range);
        float spawnZ = Random.Range(-range, range);

        Vector3 spawnPos = new Vector3(spawnX, y, spawnZ);
        return spawnPos;
    }
}
