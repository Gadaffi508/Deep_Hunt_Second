using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowproperty : ArrowScripts
{
    public override void EnemyAttack(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().hasarVeriliyor = true;
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().hasarSure = 5;
        Destroy(gameObject);
    }

    public override void EnemyAttack(Collider2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().hasarVeriliyor = true;
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().hasarSure = 5;
        Destroy(gameObject);
    }
}
