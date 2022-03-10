using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_SettingsManager : MonoBehaviour
{
    [Header("Main Menu Objects")]
    [SerializeField] private GameObject _menuManager;

    public void MainMenu()
    {
        _menuManager.SetActive(true);

        gameObject.SetActive(false);
    }
}
