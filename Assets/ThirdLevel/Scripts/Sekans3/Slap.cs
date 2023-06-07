using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slap : MonoBehaviour
{

    private Transform ship;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        ship = GameObject.FindGameObjectWithTag("Ship").transform;
        if (transform.position.x < ship.position.x)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        transform.DOMoveY(-4.7f, 1f).OnComplete(() =>
        {
            animator.SetBool("Exit", true);
            transform.DOMoveY(-4.7f, 2f).OnComplete(() => {
                animator.SetBool("Exit", false);
                transform.DOMoveY(-7f, 1).OnComplete(() => {
                    Destroy(gameObject);
                });
            });
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            //Hasar Kodlarý
        }
    }

}
