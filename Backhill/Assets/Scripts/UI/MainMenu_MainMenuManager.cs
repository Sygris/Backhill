using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_MainMenuManager : MonoBehaviour
{
    [Header("Settings Objects")]
    [SerializeField] private GameObject _settingsManager;

    public void PlayDemo()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        _settingsManager.SetActive(true);

        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
