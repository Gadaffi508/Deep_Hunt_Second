using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class KrakenUpSurFace : MonoBehaviour
{
    public float krakenHealth;
    public GameObject Kraken;
    public bool above = false;
    private Animator animator;

    private bool KrakenIsLife = true;
    public int aktifSekans = 1;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Kraken").GetComponent<Animator>();  
    }

  
    public void UpSurFace()
    {
           animator.SetBool("exit", true);
           animator.SetBool("input", false);
           Kraken.transform.DOMoveY(-2.5f, 0.7f).OnComplete(() =>
           {
               animator.SetBool("exit", false);
           });
    }

    public void DownSurFace()
    {
            animator.SetBool("input", true);
            animator.SetBool("exit", false);
            Kraken.transform.DOMoveY(-19, 1f); 
    }
}
