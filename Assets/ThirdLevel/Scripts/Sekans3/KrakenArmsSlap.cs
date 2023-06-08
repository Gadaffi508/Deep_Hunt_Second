using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KrakenArmsSlap : MonoBehaviour
{
    public GameObject Arm;
    private Transform ship;
    public Transform[] Points;
    public Transform[] Pointt;
    private Vector2 spawnPoint;
    public GameObject Warning;
    public void BossSekans2Calistir()
    {
        StartCoroutine(Timer());
    }
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").transform;
    }
    private void ArmSpawner()
    {
        int random = Random.Range(0, Points.Length);
        GameObject warning = Instantiate(Warning, Points[random].position,Quaternion.identity);
        GameObject arm = Instantiate(Arm, Points[random].position,Quaternion.identity);
    }

    IEnumerator Timer()
    {
        int random = Random.Range(0, Points.Length);
        GameObject warning = Instantiate(Warning, Pointt[random].position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        warning.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        warning.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        warning.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        GameObject arm = Instantiate(Arm, Points[random].position, Quaternion.identity);

    }
}
