using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private BossEventManager bossEventManager;
    public int bosseventNum = 1;

    public float fireRate;
    private float nextFireRate;
    private void Start()
    {
        bossEventManager = FindObjectOfType<BossEventManager>();
    }

    private void Update()
    {
        // Boss düþmanýnýn davranýþýný kontrol et
        // Belirli koþullar gerçekleþtiðinde ilgili olayý tetikle
        if (bosseventNum == 1)
        {
            if (nextFireRate < Time.time)
            {
                bossEventManager.TriggerBossEvent1();
                nextFireRate = Time.time + 1 / fireRate;
                bosseventNum = 2;
            }
           
        }
        else if (bosseventNum == 2)
        {
            if (nextFireRate < Time.time)
            {
                bossEventManager.TriggerBossEvent2();
                nextFireRate = Time.time + 1 / fireRate;
                bosseventNum = 3;
            }
           
        }
        else if (bosseventNum == 3)
        {
            if (nextFireRate < Time.time)
            {
                bossEventManager.TriggerBossEvent3();
                nextFireRate = Time.time + 1 / fireRate;
                bosseventNum = 1;
            }

        }
    }
}
