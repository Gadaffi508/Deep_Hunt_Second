using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Arrowtab : ArrowScripts
{
    public int maxRicohetSayisi = 1; // Mermiye izin verilen maksimum sekme sayýsý

    private int ricohetSayisi = 0; // Þu anki sekme sayýsý

    public override void EnemyAttack(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().HasarVer(Damage);
        target = BulEnYakinDusman();

        if (target != null)
        {
            // Yeni hedefe doðru hareket et
            transform.position = Vector2.MoveTowards(transform.position, target.position, rowSpeed * Time.deltaTime);
        }
        else
        {
            // Hedef bulunamadýysa, mermiyi yok et
            Destroy(gameObject);
        }
    }

    public override void EnemyAttack(Collider2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().HasarVer(Damage);
        target = BulEnYakinDusman();

        if (target != null)
        {
            // Yeni hedefe doðru hareket et
            transform.position = Vector2.MoveTowards(transform.position, target.position, rowSpeed * Time.deltaTime);
        }
        else
        {
            // Hedef bulunamadýysa, mermiyi yok et
            Destroy(gameObject);
        }
    }

    private Transform BulEnYakinDusman()
    {
        GameObject[] dusmanlar = GameObject.FindGameObjectsWithTag("Enemy"); // Tüm düþman nesnelerini al

        Transform enYakinDusman = null;
        float enKisaMesafe = Mathf.Infinity;

        foreach (GameObject dusman in dusmanlar)
        {
            float mesafe = Vector2.Distance(transform.position, dusman.transform.position);

            if (mesafe < enKisaMesafe)
            {
                enKisaMesafe = mesafe;
                enYakinDusman = dusman.transform;
            }
        }

        return enYakinDusman;
    }
}
