using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialSecond : MonoBehaviour
{
    public GameObject[] destg;
    public LayerMask OpenTowerObject;
    public GameObject ImageInformation;
    bool butonclęck = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, direction, float.MaxValue, OpenTowerObject);

            if (hit.collider != null)
            {
                ImageInformation.SetActive(true);
                Destroy(ImageInformation, 3f);
            }
        }
    }

    public void DestroyGameobjecs()
    {
        for (int i = 0; i < destg.Length; i++)
        {
            Destroy(destg[i]);
        }
    }
}
