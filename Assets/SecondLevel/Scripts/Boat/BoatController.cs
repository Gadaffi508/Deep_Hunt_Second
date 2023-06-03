using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoatController : MonoBehaviour
{
    [Header("Controller")]
    [Space]
    public Rigidbody2D rb;
    public float speed;
    public int direction;
    public bool isFacingRight = true;

    public int Health;
    public int damage;


    [Space]
    [Header("UI")]
    [Space]
    public Text healthText;
    public Text GoldText;

    [Space]
    [Header("Gold")]
    public int gold;

    [Space]
    [Header("Swing")]
    public float MoveDistance = .1f; // Geminin toplam hareket edeceði mesafe
    public float DistanceSpeed = 1f; // Geminin hareket hýzý

    private Vector3 StartPos; // Geminin baþlangýç konumu

    private bool stoped;

    private bool Move = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        GameManager.Instance.Health = Health;
        GameManager.Instance.Gold = gold;
        Health = 100;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
            StartPos = transform.position;
            stoped = false;
        }
        else
        {
            stoped = true;
        }

        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
    }
    IEnumerator DamageSlowTýme()
    {
        yield return new WaitForSeconds(2);
        DamageSlow(damage);
        StartCoroutine(DamageSlowTýme());

    }
    public void DamageSlow(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            //Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("kuleA"))
        {
            other.transform.parent = transform;
            Destroy(other.rigidbody);
        }
        if (other.gameObject.CompareTag("EnemyArrow"))
        {
            Destroy(other.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Clamb"))
        {
            collision.gameObject.GetComponent<ClambEnemy>().OnTrigger(this);
        }

    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -direction;
        transform.localScale = scale;
    }
    public void Swing()
    {
        float MovePosSpeed = DistanceSpeed * Time.deltaTime / 2;

        if (Move)
        {
            transform.Translate(Vector2.right * MovePosSpeed);
        }
        else
        {
            transform.Translate(Vector2.left * MovePosSpeed);
        }
        if (StartPos.x + MoveDistance < transform.position.x || StartPos.x - MoveDistance > transform.position.x)
        {
            Move =! Move;
        }
    }

}
