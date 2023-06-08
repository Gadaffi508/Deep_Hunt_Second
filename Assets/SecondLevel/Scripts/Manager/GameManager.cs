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

    public int damagedecrease = 0;

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
        Goldtext.text = Gold.ToString();
    }


    public void Heal(float healingAmount)
    {
        Health += healingAmount;

        Healtbar.fillAmount = Health / 100;
    }


    public void TakeDamage(float damage)
    {
        int random = Random.Range(0, DamageSounds.Length);
        audio.PlayOneShot(DamageSounds[random]);
        Health -= damage - (damagedecrease);
        Healtbar.fillAmount = Health / 100;
    }


}
