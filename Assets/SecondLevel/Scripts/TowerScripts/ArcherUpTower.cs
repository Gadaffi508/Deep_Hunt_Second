using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherUpTower : MonoBehaviour
{
    [Header("Upgrade Tower")]
    [SerializeField] GameObject upgradeTower;
    [Space]
    BoatController boat;
    private void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Ship").gameObject.GetComponent<BoatController>();
    }

    private void Update()
    {
        if (boat.isFacingRight)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }

    }
    public void UpgradeTowerButton()
    {
        Destroy(gameObject);
        Instantiate(upgradeTower, transform.position, Quaternion.identity);
        GetComponentInChildren<Try>().CloseTower();
    }
}
