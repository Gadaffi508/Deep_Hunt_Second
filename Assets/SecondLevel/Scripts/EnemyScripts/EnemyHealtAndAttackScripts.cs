using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemyHealtAndAttackScripts : MonoBehaviour
{
    [Header("Healt")]
    [SerializeField] private float health;
    [Header("Attack")]
    [SerializeField] public int attack;

    private Animator animator;
    public GameObject puffEffect;
    public Transform effectPoint1;
    SpriteRenderer render;
    private EnemyMove move;

    public float hasarSure = 5f; // Hasar s�resi (saniye)
    private float hasarPerSaniye = 1f; // Saniyede verilen hasar miktar�
    public bool hasarVeriliyor = false;
    void Start()
    {
        move = GetComponent<EnemyMove>();
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        render.enabled = true;
    }
    public void TakeDamage()
    {
        GameManager.Instance.TakeDamage(attack);

    }

    IEnumerator Timer()
    {
        //animator.SetBool("Dead", true);
        //move.moveSpeed = 0;
        yield return new WaitForSeconds(0.5f);
        render.enabled = false;
        Instantiate(puffEffect, effectPoint1.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (hasarVeriliyor && health > 0) // Hasar veriliyorsa ve d��man �lmediyse
        {
            hasarSure -= Time.deltaTime; // Zaman� g�ncelle
            if (hasarSure <= 0) // Hasar s�resi tamamland�ysa
            {
                hasarVeriliyor = false; // Hasar verme durdurulur
            }
            else
            {
                HasarVer(hasarPerSaniye * Time.deltaTime); // Hasar� uygula
            }
        }
    }

    public void HasarVer(float hasar)
    {
        health -=hasar;

        if (health <= 0)
        {
            GameManager.Instance.Gold += 15;
            StartCoroutine(Timer());


            Debug.Log("�ld�m");
        }
    }

}
