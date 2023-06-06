using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BossEventHandlers : MonoBehaviour
{

    public KrakenArmsSlap krakenArmSlap;
    public KrakenArms krakenArms;
    public DrunkSpawn drunkSpawn;
    public void HandleBossEvent1()
    {
        krakenArmSlap.BossSekans2Calistir();
    }

    public void HandleBossEvent2()
    {
        krakenArms.BossSekans1Calistir();
    }

    public void HandleBossEvent3()
    {
        drunkSpawn.DrunkEnemySpawn();
    }
}
