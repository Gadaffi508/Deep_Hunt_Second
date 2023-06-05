using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DrunkSpawn : MonoBehaviour
{
    public Transform[] point;
    public GameObject Enemy;
    private Transform target;
    private Animator animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Ship").transform;
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangePosition();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("krakenScream", true);
            DrunkEnemySpawn();
        }
        else
        {
            animator.SetBool("krakenScream", false);
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
