using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemyHealtAndAttackScripts : MonoBehaviour
{
    [Header("Healt")]
    [SerializeField] private int health;
    [Header("Attack")]
    [SerializeField] public int attack;

    private Animator animator;
    public GameObject puffEffect;
    public Transform effectPoint1;
    SpriteRenderer render;
    private EnemyMove move;
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


    public void DamageTaken(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameManager.Instance.Gold += 15;
            StartCoroutine(Timer());


            Debug.Log("Öldüm");
        }
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

}
