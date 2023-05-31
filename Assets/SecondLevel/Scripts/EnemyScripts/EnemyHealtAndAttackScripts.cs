using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealtAndAttackScripts : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField] public float EnemyHealth = 100;
    [SerializeField] public float DamageTaken = 15;
    [SerializeField] public int EnemyTakeDamage = 15;

    private float currentHealth;

    private GameManager gameManager;
    void Start()
    {
        currentHealth = EnemyHealth;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    public void TakeDamage(int damage)
    {
        gameManager.Health -= damage;

    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
      
        if (currentHealth <= 0)
        {
            GameManager.Instance.Gold += 20;
            Destroy(gameObject);

        }
    }

    

}
