using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraDelay : MonoBehaviour
{
    public GameObject[] targetAll;
    public int level = 1;
    Transform targetPos;
    public float speed = 2.0f;
    public Vector3 delayAmount;
    private Vector3 targetVector;

    public static CameraDelay instance;
    public GameObject Fog;

    private void Awake()
    {
        instance = this;
    }

    private IEnumerator Start()
    {
        for (int i = level; i < targetAll.Length; i++)
        {
            targetAll[i].SetActive(false);
        }
        targetAll[level].SetActive(true);

        if(level > 0)
            targetPos = targetAll[level-1].transform;
        else
            targetPos = targetAll[0].transform;


        yield return new WaitForSeconds(1);
        delayAmount = transform.position - targetPos.position;

        targetPos = targetAll[level].transform;
    }

    void LateUpdate()
    {
        if (targetPos != null)
            targetVector = targetPos.position + delayAmount;

        Vector3 yumusatilmisPozisyon = Vector3.Lerp(transform.position, targetVector, speed * Time.deltaTime);

        transform.position = yumusatilmisPozisyon;

    }
    public void FogOut()
    {
        Fog.transform.DOMoveY(-12,2);
    }
}
