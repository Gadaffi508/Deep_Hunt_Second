using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ArcherTowerBottom : MonoBehaviour
{
    [Header("Upgrade Tower")]
    [SerializeField] GameObject upgradeTower;
    [Space]
    private Transform effectPos;
    public ArrowBottom Bullet;
    public float nextPrefab;
    public GameObject bombEffect;
    BoatController boat;
    private AudioSource audio;
    public AudioClip bomb;
    public LayerMask enemyLayer; // D��manlar�n bulundu�u katman
    int facing;
    int facingLeft = 1;
    bool fire = false;
    private void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Ship").gameObject.GetComponent<BoatController>();
        audio = GetComponent<AudioSource>();
        effectPos = GetComponentInChildren<Transform>();
    }


    private void Update()
    {
        nextPrefab += Time.deltaTime;
        if (transform.position.x < boat.transform.position.x)
        {
            if (boat.transform.localScale.x == 1)
            {
                facing = -1;
                transform.localScale = new Vector2(-.7f, .7f);
            }
            else
            {
                facing = -1;
                transform.localScale = new Vector2(.7f, .7f);  
            }
        }
        else
        {
            if (boat.transform.localScale.x == -1)
            {
                facing = 1;
                transform.localScale = new Vector2(-.7f, .7f);
            }
            else
            {
                facing = 1;
                transform.localScale = new Vector2(.7f, .7f);
            }
        }

        RaycastHit2D[] hitEnemies = Physics2D.LinecastAll(transform.position, new Vector2(transform.position.x + (10 * facing), transform.position.y), enemyLayer);

        foreach (RaycastHit2D hit in hitEnemies)
        {
            Collider2D enemy = hit.collider;
            
            if (enemy != null)
            {
                fire = true;
                if (nextPrefab >= 1.5f && fire)
                {
                    ProjectTile(enemy.transform);
                    nextPrefab = 0;
                    audio.PlayOneShot(bomb);
                    Instantiate(bombEffect, effectPos.position, Quaternion.identity);
                }
            }
            else
            {
                fire = false;
            }
        }

    }

    public void ProjectTile(Transform enemy)
    {
        GameObject row = Instantiate(Bullet,transform.position,transform.rotation).gameObject;
        if (transform.position.x < boat.transform.position.x)
        {
            if (boat.transform.localScale.x == 1)
            {
                row.GetComponent<Transform>().localScale = new Vector2(-1, 1);
            }
            else
            {
                row.GetComponent<Transform>().localScale = new Vector2(-1, 1);
            }
        }
        else
        {
            if (boat.transform.localScale.x == -1)
            {
                row.GetComponent<Transform>().localScale = new Vector2(1, 1);
            }
            else
            {
                row.GetComponent<Transform>().localScale = new Vector2(1, 1);
            }
        }
        ArrowBottom arrow = row.GetComponent<ArrowBottom>();
        arrow.SetTarget(enemy);
    }

    private void OnDrawGizmos()
    {
        int facing;
        if (boat.transform.localScale.x == 1)
        {
            facing = -1;
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            facing = 1;
            transform.localScale = new Vector2(1, 1);
        }

        Gizmos.color = UnityEngine.Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + (10 * facing), transform.position.y));
    }

    public void UpgradeTowerButton()
    {
        Destroy(gameObject);
        Instantiate(upgradeTower, transform.position, Quaternion.identity);
        GetComponentInChildren<Try>().CloseTower();
    }
}
