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
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").transform;
        StartCoroutine(Timer());
    }
  

    private void ArmSpawner()
    {
       
        int random = Random.Range(0, Points.Length);
       
        GameObject arm = Instantiate(Arm, Points[random].position,Quaternion.identity);

      
    }

    IEnumerator Timer()
    {
        ArmSpawner();
        yield return new WaitForSeconds(3);
        StartCoroutine(Timer());
    }
}
