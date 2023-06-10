using UnityEngine;

public class TowerButtonController : MonoBehaviour
{
    [SerializeField] BuiltTower[] allButtons;

    private tower currentArea;
    public tower SetTower(tower tower) => currentArea = tower;
    public bool clicked = false;

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
            clicked = true;
        }
    }
}
