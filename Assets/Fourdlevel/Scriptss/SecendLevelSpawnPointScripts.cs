using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecendLevelSpawnPointScripts : MonoBehaviour
{
    public GameObject tankEnemy;
    public GameObject SmallEnemy;
    public GameObject DrunkEnemy;
    public GameObject GirdapEnemy;
    public GameObject FlyEnemy;
    public GameObject clambEnemy;


    private Vector2 SeaPoint;






    private Transform target;

    private void Start()
    {
        SpawnerTimer();
    }

    private void SpawnerTwo()
    {
        StartCoroutine("SpawnerTimer");
    }


    IEnumerator SpawnerTimer()
    {
        //Wave 1
        for (int i = 0; i < 5; i++)
        {
            int random1 = Random.Range(0, 2);
            if (random1 == 0)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                SeaPoint = new Vector2(target.position.x + 10f,-4f);
                Instantiate(tankEnemy,SeaPoint,Quaternion.identity);
            }
            else if (random1 == 1)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                SeaPoint = new Vector2(target.position.x - 10f, -4f);
                Instantiate(tankEnemy, SeaPoint, Quaternion.identity);
            }
            for (int a = 0; a < 3; a++)
            {
                Instantiate(SmallEnemy, SeaPoint, Quaternion.identity);
                yield return new WaitForSeconds(2);
            }
        }
        yield return new WaitForSeconds(12);
        //Wave 2
    }

}
