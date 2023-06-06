using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTopController : MonoBehaviour
{
    [SerializeField] BuiltTower[] allButtons;

    private TowerUp currentArea;
    public TowerUp SetTower(TowerUp towerU) => currentArea = towerU;

    //Event Implements
    private void OnEnable()
    {
        foreach (var button in allButtons)
        {
            button.OnButtonClick += ButtonClick;
        }
    }
    private void OnDisable()
    {
        foreach (var button in allButtons)
        {
            button.OnButtonClick -= ButtonClick;
        }
    }
    private void ButtonClick(GameObject _Tower)
    {
        if (currentArea != null)
        {
            currentArea.TowerBuilt(_Tower);
        }
    }
}
