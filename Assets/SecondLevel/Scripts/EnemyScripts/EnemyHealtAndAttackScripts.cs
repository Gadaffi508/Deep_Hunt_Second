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

    private GameManager gameManager;
    void Start()
    {
        curentHealth = health;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
            Destroy(gameObject);
            Debug.Log("Öldüm");
        }
    }

    

}
