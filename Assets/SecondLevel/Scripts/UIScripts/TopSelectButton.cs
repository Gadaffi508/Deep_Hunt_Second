using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TopSelectButton : MonoBehaviour, IPointerEnterHandler
{
    public BulletScriptable bullet;
    public Image BulletSprite;

    //Events
    public event Action<BulletScriptable> OnButtonClick;
    public event Action<BulletScriptable> OnButtonEnter;

    //private variables
    private Button button;
    TowerS towerGold;

    private void Start()
    {
        towerGold = GetComponent<TowerS>();

        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);

        BulletSprite.sprite = bullet.spt.sprite;
    }


    //Mouse on Button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnButtonEnter != null)
            OnButtonEnter.Invoke(bullet);
    }
    //Mouse on click
    public void OnClick()
    {
        if (GameManager.Instance.Gold >= towerGold.buyTower)
        {
            if (OnButtonClick != null)
            {
                OnButtonClick(bullet);
                GameManager.Instance.built = true;
                if (GetComponentInParent<RawImage>().name == "bg")
                {
                    GetComponentInParent<GameObject>().gameObject.transform.DOMoveY(1500, 1);
                }

            }
            towerGold.BuyTower();
        }
        else
        {
            Debug.Log("No money");
        }
    }
}
