using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoatManager : MonoBehaviour
{
    public Text nameText;
    public int direction;
    public int sceneID;
    public SpriteRenderer spt;
    int der;

    private void Awake()
    {
        spt = GetComponent<SpriteRenderer>();
        Save("direction", direction);
        der = PlayerPrefs.GetInt("direction", direction);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    private void OnMouseDown()
    {
        ChangeScene(sceneID);
        Save("direction", direction);
    }
    public void Save(string KeyName, int _direction)
    {
        PlayerPrefs.SetInt(KeyName, _direction);
    }
    private void OnMouseEnter()
    {
        spt.sortingOrder = 2;
        transform.localScale = new Vector2(1.25f,1.25f);
    }
    private void OnMouseExit()
    {
        spt.sortingOrder = 1;
        transform.localScale = new Vector2(1, 1);
    }
}
