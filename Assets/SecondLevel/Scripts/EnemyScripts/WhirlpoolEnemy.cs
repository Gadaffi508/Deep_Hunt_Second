using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class WhirlpoolEnemy : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private LayerMask shipLayer;
    


    [Header("Attribute")]
    [SerializeField] private float attackRange = 15f;
    [SerializeField] private float Force;
    [SerializeField] private float Speed;

    private Rigidbody2D rb;
    private Transform target;
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, attackRange);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      

    }
    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Ship").transform;
        if (transform.position.x > target.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1f);
        }
    }
  
    void FixedUpdate()
    {
        if (transform.position.x > target.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1f);
            rb.velocity = new Vector2(-Speed * Time.deltaTime, rb.velocity.y);
        }
        else if (transform.position.x < target.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1f);
            rb.velocity = new Vector2(Speed * Time.deltaTime, rb.velocity.y);
        }
        RaycastHit2D hits = Physics2D.CircleCast(transform.position, attackRange, (Vector2)transform.position, 0f, shipLayer);

        if (hits)
        {
           
            transform.DOMoveY(-6.5f, 1).OnComplete(() =>
            {
                Speed = 0;
                Whirlpool();
            });
        }
        else 
        {
            transform.DOMoveY(-4.5f, 1).OnComplete(() =>
            {
                Speed = 75;
            });
           
        }
    }


    private void Whirlpool()
    {
        if (transform.position.x > target.position.x)
        {
            target.transform.Translate(Force,0,0);
        }
        else if (transform.position.x < target.position.x)
        {
            target.transform.Translate(-Force, 0, 0);
        }
    }

  
}
