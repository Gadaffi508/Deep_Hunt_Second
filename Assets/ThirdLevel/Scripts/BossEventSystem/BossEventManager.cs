using UnityEngine;
using UnityEngine.Events;

public class BossEventManager : MonoBehaviour
{
    public UnityEvent bossEvent1;
    public UnityEvent bossEvent2;
    public UnityEvent bossEvent3;

    public void TriggerBossEvent1()
    {
        bossEvent1.Invoke();
    }

    public void TriggerBossEvent2()
    {
        bossEvent2.Invoke();
    }

    public void TriggerBossEvent3()
    {
        bossEvent3.Invoke();
    }
}
