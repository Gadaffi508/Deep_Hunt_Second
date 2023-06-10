using UnityEngine;

public class GunInformation : MonoBehaviour
{
    public GameObject gunınforma;

    TowerButtonController buton;

    private void Start()
    {
        buton = GetComponent<TowerButtonController>();
        gunınforma.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (buton.clicked == true)
        {
            buton.clicked = false;
            if (gunınforma != null)
            {
                gunınforma.SetActive(true);
                Destroy(gunınforma, 3f);
            }
        }
    }

}