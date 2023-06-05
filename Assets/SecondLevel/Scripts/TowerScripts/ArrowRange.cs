using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRange : ArrowScripts
{
    public float maxDamage = 30f; // Maksimum zarar de�eri
    public float minDamage = 1f; // Minimum zarar de�eri
    public float maxDistance = 1f; // Maksimum mesafe
    public float minDistance = 0.2f; // Minimum mesafe

    public override void EnemyAttack(Collision2D collision)
    {
        float distance = Vector2.Distance(transform.position, collision.transform.position);
        Debug.Log(distance);

        // Mesafeye ba�l� olarak zarar� hesapla
        Damage = (int)CalculateDamage(distance);
        Debug.Log(Damage);

        // D��mana zarar� uygula
        EnemyHealtAndAttackScripts enemyController = collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>();
        if (enemyController != null)
        {
            enemyController.DamageHealth(Damage);
            Destroy(gameObject);
        }
    }

    public override void EnemyAttack(Collider2D collision)
    {
        float distance = Vector2.Distance(transform.position, collision.transform.position);
        Debug.Log(distance);

        // Mesafeye ba�l� olarak zarar� hesapla
        Damage = (int)CalculateDamage(distance);
        Debug.Log(Damage);

        // D��mana zarar� uygula
        EnemyHealtAndAttackScripts enemyController = collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>();
        if (enemyController != null)
        {
            enemyController.DamageHealth(Damage);
            Destroy(gameObject);
        }
    }

    private float CalculateDamage(float distance)
    {
        // Mesafeye ba�l� olarak zarar� hesapla
        float normalizedDistance = Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
        float damage = Mathf.Lerp(maxDamage, minDamage, normalizedDistance);
        return damage;
    }
}
