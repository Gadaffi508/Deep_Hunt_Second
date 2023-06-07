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
    private KrakenManager manager;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KrakenManager>();
        target = GameObject.FindGameObjectWithTag("Ship").transform;
        animator = GetComponent<Animator>();

    }
    //void OnEnable()
    //{
    //    manager.BossSekans3Tetiklendi += BossSekans3Calistir;

    //}
    //void OnDisable()
    //{
    //    manager.BossSekans3Tetiklendi -= BossSekans3Calistir;

    //}

    void BossSekans3Calistir()
    {
        animator.SetBool("krakenScream", true);
        DrunkEnemySpawn();
    }
  

    
    void Update()
    {

       

       
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

    public void DrunkEnemySpawn()
    {
        ChangePosition();
        for (int i = 0; i < point.Length; i++)
        {
            GameObject enemy = Instantiate(Enemy, point[i].position,Quaternion.identity); 
        }

       
    }

   
}
