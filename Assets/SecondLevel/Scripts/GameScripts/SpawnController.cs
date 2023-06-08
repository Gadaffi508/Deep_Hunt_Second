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
            random = Random.Range(0,spawnPointsSwim.Length);
            yield return new WaitForSeconds(2f);
            Instantiate(enemySwim, spawnPointsSwim[random].position, Quaternion.identity);
            for (int i = 0; i < littleSwim; i++)
            {
                Instantiate(enemyLittleSwim, spawnPointsSwim[random].position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
           
        }

       

    }
}
