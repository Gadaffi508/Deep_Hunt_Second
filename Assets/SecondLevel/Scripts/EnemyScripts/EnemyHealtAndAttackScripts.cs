using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemyHealtAndAttackScripts : MonoBehaviour
{
    [Header("Healt")]
    [SerializeField] private int health;
    [Header("Attack")]
    [SerializeField] private int attack;

    private int curentHealth;

    private Animator animator;
    public GameObject puffEffect;
    public Transform effectPoint1;
    private GameManager gameManager;
    SpriteRenderer render;
    private EnemyMove move;
    void Start()
    {
        move = GetComponent<EnemyMove>();
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        curentHealth = health;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        render.enabled = true;
    }
    public void TakeDamage(int damage)
    {
        gameManager.Health -= damage;

    }
   

    public void DamageTaken(int damage)
    {
        curentHealth -= damage;

        if (curentHealth <= 0)
        {
            gameManager.Gold += 15;
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
