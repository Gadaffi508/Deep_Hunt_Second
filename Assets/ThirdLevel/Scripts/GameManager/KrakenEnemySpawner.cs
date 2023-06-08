using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenEnemySpawner : MonoBehaviour
{
    public GameObject tankEnemy;
    public GameObject normalEnemy;

    public Transform[] points;

    public int numberOfWave;

    public int normalEnemyNumber;
    void Start()
    {
        
    }
    public void EnemySpawner()
    {
        StartCoroutine(SpawnerTimer());
    }
    IEnumerator SpawnerTimer()
    {
        for (int i = 0; i < numberOfWave; i++)
        {
            int random = Random.Range(0, points.Length);
            yield return new WaitForSeconds(2f);
            Instantiate(tankEnemy, points[random].position, Quaternion.identity);
            for (int c = 0; c < normalEnemyNumber; c++)
            {
                Instantiate(normalEnemy, points[random].position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitForSeconds(5f);
        }
    }
   
}
