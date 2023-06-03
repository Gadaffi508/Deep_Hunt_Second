using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Goldtext;
    public Text HealthText;

    public int Gold;
    public float Health;

    public Image Healtbar;
    public GameObject HealtbarBG;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        HealtbarBG.SetActive(true);
        Healtbar.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        Goldtext.text = "Gold : " + Gold.ToString();
    }


    public void Heal(float healingAmount)
    {
        Health += healingAmount;
        Health = Mathf.Clamp(healingAmount, 0, 100);

        Healtbar.fillAmount = healingAmount / 100;
    }


    public void TakeDamage(float damage)
    {
        Health -= damage;
        Healtbar.fillAmount = Health / 100;
    }


}
