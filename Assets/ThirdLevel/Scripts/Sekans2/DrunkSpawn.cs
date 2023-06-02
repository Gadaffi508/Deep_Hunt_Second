using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DrunkSpawn : MonoBehaviour
{
    public Transform[] point;
    public GameObject Enemy;
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Ship").transform;
      
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangePosition();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DrunkEnemySpawn();
        }
    }

    private void ChangePosition()
    {
        if (target.transform.position.x > 0)
        {
            for (int i = 0; i < point.Length; i++)
            {
                point[i].transform.position = new Vector3(point[i].transform.position.x * -1, point[i].transform.position.y, point[i].transform.position.z);
            }
        }
        else
        {
            for (int i = 0; i < point.Length; i++)
            {
                point[i].transform.position = new Vector3(point[i].transform.position.x * -1, point[i].transform.position.y, point[i].transform.position.z);
            }
        } 
    }

    private void DrunkEnemySpawn()
    {
        for (int i = 0; i < point.Length; i++)
        {
            GameObject enemy = Instantiate(Enemy, point[i].position,Quaternion.identity);
        }

        
    }
}
