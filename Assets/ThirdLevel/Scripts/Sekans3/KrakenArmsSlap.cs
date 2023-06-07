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
    public void BossSekans2Calistir()
    {
        ArmSpawner();
    }
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").transform;
    }
    private void ArmSpawner()
    {
        int random = Random.Range(0, Points.Length);
        GameObject arm = Instantiate(Arm, Points[random].position,Quaternion.identity);
    }
}
