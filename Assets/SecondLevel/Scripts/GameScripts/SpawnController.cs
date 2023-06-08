using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpawnController : MonoBehaviour
{
    [Header("WaveChekc")]
    [SerializeField] private bool waveSend;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private int howManyWaves = 10;

    [Header("SpawnPoints")]
    [SerializeField] private Transform[] spawnPointsSwim;
    [SerializeField] private Transform[] SpawnPointsFlay;


    [Header("Enemys")]
    [SerializeField] private GameObject enemySwim;
    [SerializeField] private GameObject enemyLittleSwim;
    [SerializeField] private GameObject flyEnemy;
    [SerializeField] private GameObject drunkEnemy;




    private int random;
    private int random1;
    private int vaweControl = 1;
    private bool WaveCheck;
    void Start()
    {
        StartCoroutine(Timer());

    }
    IEnumerator Timer()
    {
        if (waveSend)
        {
            random = Random.Range(0, spawnPointsSwim.Length);
            yield return new WaitForSeconds(3f);
            Instantiate(enemySwim, spawnPointsSwim[random].position, Quaternion.identity);
            for (int i = 0; i < 3; i++)
            {
                Instantiate(enemyLittleSwim, spawnPointsSwim[random].position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(12f);

            for (int a = 0; a < 3; a++)
            {
                random = Random.Range(0, spawnPointsSwim.Length);
                yield return new WaitForSeconds(3f);
                Instantiate(enemySwim, spawnPointsSwim[random].position, Quaternion.identity);
                for (int i = 0; i < 6; i++)
                {
                    Instantiate(enemyLittleSwim, spawnPointsSwim[random].position, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                }

                yield return new WaitForSeconds(3f);
            }

            yield return new WaitForSeconds(12f);

            for (int a = 0; a < 2; a++)
            {
                random = Random.Range(0, spawnPointsSwim.Length);
                yield return new WaitForSeconds(3f);
                Instantiate(enemySwim, spawnPointsSwim[random].position, Quaternion.identity);
                for (int i = 0; i < 3; i++)
                {
                    Instantiate(enemyLittleSwim, spawnPointsSwim[random].position, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                }
                for (int b = 0; b < 3; b++)
                {
                    Instantiate(flyEnemy, SpawnPointsFlay[random].position, Quaternion.identity);
                    yield return new WaitForSeconds(3f);
                }
                yield return new WaitForSeconds(3f);
            }

            yield return new WaitForSeconds(12f);

            for (int a = 0; a < 4; a++)
            {
                random = Random.Range(0, spawnPointsSwim.Length);
                Instantiate(drunkEnemy, SpawnPointsFlay[random].position, Quaternion.identity);
                yield return new WaitForSeconds(3f);
                Instantiate(enemySwim, spawnPointsSwim[random].position, Quaternion.identity);
                for (int i = 0; i < 3; i++)
                {
                    Instantiate(enemyLittleSwim, spawnPointsSwim[random].position, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                }
                for (int b = 0; b < 2; b++)
                {
                    Instantiate(flyEnemy, SpawnPointsFlay[random].position, Quaternion.identity);
                    yield return new WaitForSeconds(3f);
                }
                yield return new WaitForSeconds(3f);
            }

            yield return new WaitForSeconds(12f);

            for (int a = 0; a < 6; a++)
            {
                random = Random.Range(0, spawnPointsSwim.Length);
                Instantiate(drunkEnemy, SpawnPointsFlay[random].position, Quaternion.identity);
                yield return new WaitForSeconds(3f);
                Instantiate(enemySwim, spawnPointsSwim[random].position, Quaternion.identity);
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(enemyLittleSwim, spawnPointsSwim[random].position, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                }
                for (int b = 0; b < 2; b++)
                {
                    Instantiate(flyEnemy, SpawnPointsFlay[random].position, Quaternion.identity);
                    yield return new WaitForSeconds(3f);
                }
                yield return new WaitForSeconds(3f);
            }
            yield return new WaitForSeconds(0.5f);
            for (int a = 0; a < 6; a++)
            {
                random = Random.Range(0, spawnPointsSwim.Length);
                Instantiate(drunkEnemy, SpawnPointsFlay[random].position, Quaternion.identity);
                yield return new WaitForSeconds(3f);
                Instantiate(enemySwim, spawnPointsSwim[random].position, Quaternion.identity);
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(enemyLittleSwim, spawnPointsSwim[random].position, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                }
                for (int b = 0; b < 2; b++)
                {
                    Instantiate(flyEnemy, SpawnPointsFlay[random].position, Quaternion.identity);
                    yield return new WaitForSeconds(3f);
                }
                yield return new WaitForSeconds(3f);
            }
        }
    }
}
