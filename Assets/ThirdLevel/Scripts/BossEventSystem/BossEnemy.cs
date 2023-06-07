using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private BossEventManager bossEventManager;
    public int bosseventNum = 1;

    public float fireRate;
    private float nextFireRate;
    private Animator animator;


    
    private void Start()
    {
        bossEventManager = FindObjectOfType<BossEventManager>();
        animator = GetComponent<Animator>();        
    }

    private void FixedUpdate()
    {
       

        if (HealthAboveThreshold()) {

            if (TimeElapsedEvent1())
            {
                bossEventManager.TriggerBossEvent1();
                animator.SetBool("krakenScream", false);
            }
        }
        else if (HealthBelowThreshold())
        {
            if (TimeElapsedEvent2())
            {
                bossEventManager.TriggerBossEvent3();
                animator.SetBool("krakenScream", true);
            }
            else if (TimeElapsedEvent1())
            {
                bossEventManager.TriggerBossEvent1();
                animator.SetBool("krakenScream", false);
            }
            else
            {
                animator.SetBool("krakenScream", false);
            }           
        }
       

     


        Debug.Log(TimeElapsedEvent1());

       
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
    public float elapsedTimeEvent2 = 0f;
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
