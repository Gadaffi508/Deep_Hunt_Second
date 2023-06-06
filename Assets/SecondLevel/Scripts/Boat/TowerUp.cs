using DG.Tweening;
using UnityEngine;

public class TowerUp : BoatTowerController
{
    public GameObject TowerPanel;

    private void Start()
    {
        TowerPanel = GameObject.FindGameObjectWithTag("PanelFive").gameObject;
    }

    public override void CloseTower()
    {
        if (TowerPanel != null)
        {
            TowerPanel.transform.DOMoveY(1500, 1);
            TowerPanel.GetComponent<TowerTopController>().SetTower(null);
        }
    }

    public override void TowerBuilt()
    {
        if (TowerPanel != null)
        {
            TowerPanel.transform.DOMoveY(950, 1);
            TowerPanel.GetComponent<TowerTopController>().SetTower(this);
        }
    }

    public GameObject TowerBuilt(GameObject _Tower)
    {
        CloseTower();
        Destroy(gameObject);
        return Instantiate(_Tower, transform.position, Quaternion.identity);
    }
}
