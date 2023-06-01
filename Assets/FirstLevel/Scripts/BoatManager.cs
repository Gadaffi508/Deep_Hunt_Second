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
    int der;

    private void Awake()
    {
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
}
