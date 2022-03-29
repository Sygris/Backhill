using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchNotesManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;

    public void GoToPatchNotes()
    {
        _mainMenu.SetActive(false);
        gameObject.SetActive(true);
    }

    public void GoToMainMenu()
    {
        _mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
