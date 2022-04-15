using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNavigation : MonoBehaviour
{
    [SerializeField] private GameObject _wardMapIcons;
    [SerializeField] private GameObject _LobbyMapIcons;

    public void DisplayWard()
    {
        _wardMapIcons.SetActive(true);
        _LobbyMapIcons.SetActive(false);
    }

    public void DisplayLobby()
    {
        _wardMapIcons.SetActive(false);
        _LobbyMapIcons.SetActive(true);
    }
}
