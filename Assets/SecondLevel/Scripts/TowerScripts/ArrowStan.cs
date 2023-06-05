using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStan : ArrowScripts
{
    public float explosionRadius = 2f; // Patlama alan�n�n yar��ap�
    public float freezeDuration = 1f; // D��manlar�n donma s�resi

    public override void EnemyAttack(Collision2D collision)
    {
        // D��manlar� dondurmak i�in bir alan olu�tur
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // D��man� dondurmak i�in �zel bir script �a��r
                EnemyMove enemyController = enemy.GetComponent<EnemyMove>();
                if (enemyController != null)
                {
                    enemyController.Freeze(freezeDuration);
                }

                EnemyHealtAndAttackScripts enemyHealth = enemy.GetComponent<EnemyHealtAndAttackScripts>();
                if (enemyHealth != null)
                {
                    enemyHealth.DamageHealth(Damage);
                }
            }
        }
    }

    public override void EnemyAttack(Collider2D collision)
    {
        // D��manlar� dondurmak i�in bir alan olu�tur
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // D��man� dondurmak i�in �zel bir script �a��r
                EnemyMove enemyController = enemy.GetComponent<EnemyMove>();
                if (enemyController != null)
                {
                    enemyController.Freeze(freezeDuration);
                }

                EnemyHealtAndAttackScripts enemyHealth = enemy.GetComponent<EnemyHealtAndAttackScripts>();
                if (enemyHealth != null)
                {
                    enemyHealth.DamageHealth(Damage);
                }
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        // Patlama alan�n� g�rselle�tirmek i�in Gizmos kullan
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
