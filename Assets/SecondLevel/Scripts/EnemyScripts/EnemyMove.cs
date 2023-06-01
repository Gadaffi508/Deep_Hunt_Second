using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;


    [Header("Attribute")]
    [SerializeField] public float moveSpeed = 3f;


    public float prevMoveSpeed;
    private EnemyHealtAndAttackScripts script;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        script = GetComponent<EnemyHealtAndAttackScripts>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        animator.SetBool("touched", false);
        Physics2D.queriesStartInColliders = true;
        prevMoveSpeed = moveSpeed;
        if (transform.position.x > target.position.x)
        {
            moveSpeed *= -1;
            transform.localScale = new Vector3(1,1,1f);
        }
        else
        {
            moveSpeed *= 1;
            transform.localScale = new Vector3(-1, 1, 1f);
        }
    }
    private void Update()
    {
        Physics2D.queriesStartInColliders = true;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed * Time.deltaTime,rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            animator.SetBool("touched",true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            animator.SetBool("touched", false);
        }
    }
}
