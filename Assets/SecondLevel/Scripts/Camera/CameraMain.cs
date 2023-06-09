using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMain : MonoBehaviour
{
    Transform targetPos;
    public float speed = 2.0f;
    public Vector3 delayAmount;
    private Vector3 targetVector;
    [Space]
    private bool titremeDevamEdiyor = false;
    private Vector3 orijinalPozisyon;
    private float titremeSiddeti = 0.1f;
    private float titremeSure = 1f;


    public static CameraMain Cam�nstance;

    public GameObject Fog;

    private void Awake()
    {
        if (Cam�nstance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Cam�nstance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);
        Fog.transform.DOMoveY(20,1);
        yield return new WaitForSeconds(1);
        targetPos = GameObject.FindGameObjectWithTag("Ship").transform;
        // Karakter ile kamera aras�ndaki ba�lang�� mesafesini belirlemek i�in kullan�l�r.
        delayAmount = transform.position - targetPos.position;
    }

    void LateUpdate()
    {
        if(targetPos != null)
            targetVector = targetPos.position + delayAmount;

        Vector3 yumusatilmisPozisyon = Vector3.Lerp(transform.position, targetVector, speed * Time.deltaTime);

        transform.position = new Vector3(yumusatilmisPozisyon.x,transform.position.y,transform.position.z);

    }

    void BaslatTitreme()
    {
        if (!titremeDevamEdiyor)
        {
            orijinalPozisyon = transform.position;
            titremeDevamEdiyor = true;
            InvokeRepeating("TitremeEfekti", 0f, 0.01f);
            Invoke("DurdurTitreme", titremeSure);
        }
    }

    void TitremeEfekti()
    {
        float titremeX = Random.Range(-titremeSiddeti, titremeSiddeti);
        float titremeY = Random.Range(-titremeSiddeti, titremeSiddeti);
        float titremeZ = Random.Range(-titremeSiddeti, titremeSiddeti);

        transform.position = new Vector3(orijinalPozisyon.x + titremeX, orijinalPozisyon.y + titremeY, orijinalPozisyon.z + titremeZ);
    }

    void DurdurTitreme()
    {
        titremeDevamEdiyor = false;
        CancelInvoke("TitremeEfekti");
        transform.position = orijinalPozisyon;
    }
}
