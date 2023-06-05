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

    private AudioSource audio;

    public AudioClip[] DamageSounds;
    public static GameManager Instance;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
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
        int random = Random.Range(0, DamageSounds.Length);
        audio.PlayOneShot(DamageSounds[random]);
        Health -= damage;
        Healtbar.fillAmount = Health / 100;
    }


}
