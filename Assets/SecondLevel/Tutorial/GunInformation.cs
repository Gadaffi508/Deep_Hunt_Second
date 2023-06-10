using UnityEngine;

public class GunInformation : MonoBehaviour
{
    public GameObject gun�nforma;

    TowerButtonController buton;

    private void Start()
    {
        buton = GetComponent<TowerButtonController>();
        gun�nforma.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (buton.clicked == true)
        {
            buton.clicked = false;
            if (gun�nforma != null)
            {
                gun�nforma.SetActive(true);
                Destroy(gun�nforma, 3f);
            }
        }
    }

}