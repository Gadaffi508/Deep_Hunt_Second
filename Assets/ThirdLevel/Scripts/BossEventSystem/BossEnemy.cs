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
        // Boss d��man�n�n davran���n� kontrol et
        // Belirli ko�ullar ger�ekle�ti�inde ilgili olay� tetikle
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
