using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Settings Objects")]
    [SerializeField] private GameObject _settingsManager;
    [SerializeField] private List<GameObject> _enabledObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> _disabledObjects = new List<GameObject>();

    public void PlayDemo()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        _settingsManager.SetActive(true);

        foreach (GameObject item in _enabledObjects)
            item.SetActive(false);

        foreach (GameObject item in _disabledObjects)
            item.SetActive(true);

        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
