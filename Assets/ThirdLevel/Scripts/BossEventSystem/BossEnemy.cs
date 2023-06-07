using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private BossEventManager bossEventManager;
    private Animator animator;
    private void Start()
    {
        bossEventManager = FindObjectOfType<BossEventManager>();
        animator = GetComponent<Animator>();        
    }

    private void FixedUpdate()
    {

        if (KrakenDown())
        {
            //if (TimeElapsedEvent1())
            //{
            //    bossEventManager.TriggerBossEvent1();
            //    animator.SetBool("krakenScream", false);
            //}
            bossEventManager.KrakenDownEvent();

            animator.SetBool("krakenScream", false);
            //SwapnKontrol
        }
        else
        {
            bossEventManager.KrakenUpEvent();
            animator.SetBool("krakenScream", false);
        }

       
    }
  
        //if (HealthAboveThreshold()) {

        //    if (TimeElapsedEvent1())
        //    {
        //        bossEventManager.TriggerBossEvent1();
        //        animator.SetBool("krakenScream", false);
        //    }
        //}
        //else if (HealthBelowThreshold())
        //{
        //    if (TimeElapsedEvent2())
        //    {
        //        bossEventManager.TriggerBossEvent3();
        //        animator.SetBool("krakenScream", true);
        //    }
        //    else if (TimeElapsedEvent1())
        //    {
        //        bossEventManager.TriggerBossEvent1();
        //        animator.SetBool("krakenScream", false);
        //    }
        //    else
        //    {
        //        animator.SetBool("krakenScream", false);
        //    }           
        //}

    public float elapsedTimeKrakenDown = 0f;
    public float targetTimeKrakenDown = 0f;
    private bool KrakenDown()
    {
        elapsedTimeKrakenDown += Time.deltaTime;

        if (elapsedTimeKrakenDown <= targetTimeKrakenDown)
        {
            return true;

        }
        else if (elapsedTimeKrakenDown >= targetTimeKrakenDown)
        {

            if (elapsedTimeKrakenDown >= 40)
            {
                elapsedTimeKrakenDown = 0;
                return KrakenDown();
            }
            return false;
        }
       
    
        return false;
    }

    public float elapsedTimeKrakenUp = 0f;
    public float targetTimeKrakenUp = 0f;
    private bool KrakenUp()
    {
        elapsedTimeKrakenUp += Time.deltaTime;

        if (elapsedTimeKrakenUp >= targetTimeKrakenUp)
        {
            elapsedTimeKrakenUp = 0f;
            return false;
        }

        return true;
    }

    public float elapsedTimeEvent1 = 0f;
    public float targetTimeEvent1 = 0f;

    private bool TimeElapsedEvent1()
    {
        elapsedTimeEvent1 += Time.deltaTime;

        if (elapsedTimeEvent1 >= targetTimeEvent1)
        {
            elapsedTimeEvent1 = 0f;
            return true;
        }

        return false;
    }
    public float elapsedTimeEvent2 = 9f;
    public float targetTimeEvent2 = 0f;
    private bool TimeElapsedEvent2()
    {
        elapsedTimeEvent2 += Time.deltaTime;

        if (elapsedTimeEvent2 >= targetTimeEvent2)
        {
            elapsedTimeEvent2 = 0f;
            return true;
        }

        return false;
    }

    public float health = 100f;
    public float threshold = 30f;

    private bool HealthBelowThreshold()
    {

        if (health <= threshold)
        {
            return true;
        }

        return false;
    }

    private bool HealthAboveThreshold()
    {

        if (health >= threshold)
        {
            return true;
        }

        return false;
    }
}
