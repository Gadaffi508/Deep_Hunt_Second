using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class KrakenManager : MonoBehaviour
{
    public float krakenHealth;
    public GameObject Kraken;
    public bool above = false;
    private Animator animator;

    private bool KrakenIsLife = true;

    public event Action BossSekans1Tetiklendi;
    public event Action BossSekans2Tetiklendi;
    public event Action BossSekans3Tetiklendi;
    public int aktifSekans = 1;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Kraken").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (krakenHealth >= 50)
        //{
        //    DownSurFace(above);
        //    above = true;

        //}
        //else
        //{ 
        //    above = false;
        //    UpSurFace(above);
            
        //}
        if (KrakenIsLife)
        {
            if (aktifSekans == 1 && BossSekans1Tetiklendi != null)
            {
                BossSekans1Tetiklendi.Invoke();
            }
            else if (aktifSekans == 2 && BossSekans2Tetiklendi != null)
            {
                BossSekans2Tetiklendi.Invoke();
            }
            else if (aktifSekans == 3 && BossSekans3Tetiklendi != null)
            {
                BossSekans3Tetiklendi.Invoke();
            }
        }

    }

    //private void UpSurFace(bool above)
    //{
    //    if (!above)
    //    {
    //       animator.SetBool("exit", true);
    //       animator.SetBool("input", false);
    //       Kraken.transform.DOMoveY(-3, 0.7f).OnComplete(() =>
    //       {
    //           animator.SetBool("exit", false);
    //       });
    //       above = true;
    //    }
       
    //}

    //private void DownSurFace(bool above)
    //{
    //    if (above)
    //    {
    //        animator.SetBool("input", true);
    //        animator.SetBool("exit", false);
    //        Kraken.transform.DOMoveY(-8, 1f);
    //        above = false;
    //    }
    //}

}
