using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject[] EnemyPrefab;
    private int enemyCount;
    private float spawnRangeX;
    private float spawnZMin;
    private float spawnZMax;




    public void EnemySpawner(int enemyCount)
    {
        if (enemyCount > 1)
        {
            for (int x = 0; x < enemyCount; ++x)
            {
                Vector3 position = new Vector3(10f * x, 2.5f  * 0.3f, 0);
                object p = Instantiate(EnemyPrefab[enemyCount], GenerateSpawnPosition(), Quaternion.identity);
            }
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }
}
