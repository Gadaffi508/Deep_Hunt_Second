using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KrakenArmsSlap : MonoBehaviour
{
    public GameObject Arm;
    private Transform ship;
    public Transform[] Points;
    private Vector2 spawnPoint;
    private KrakenManager manager;
   

   

   public  void BossSekans2Calistir()
    {
        ArmSpawner();
    }
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KrakenManager>();
        ship = GameObject.FindGameObjectWithTag("Ship").transform;
       
    }
  

    private void ArmSpawner()
    {
       
        int random = Random.Range(0, Points.Length);
       
        GameObject arm = Instantiate(Arm, Points[random].position,Quaternion.identity);

      
    }

  
}
