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


    [Header("Enemys")]
    [SerializeField] private GameObject enemySwim;
    [SerializeField] private GameObject enemyLittleSwim;

    [Header("WaveNumber")]
    [SerializeField] private int swimEnemy;
    [SerializeField] private int littleSwim;


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
            for (int i = 0; i < howManyWaves; i++)
            {
                for (int a = 0; a < littleSwim; a++)
                {
                    random = Random.Range(0,spawnPointsSwim.Length);
                    Instantiate(enemyLittleSwim, spawnPointsSwim[random].position,Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                }

                yield return new WaitForSeconds(2f);

                for (int a = 0; a < swimEnemy; a++)
                {
                    random = Random.Range(0, spawnPointsSwim.Length);
                    Instantiate(enemySwim, spawnPointsSwim[random].position, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                }
            }
           
        }

       

    }
}
