using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    [SerializeField] private List<TabButton> _tabButtons;

    public void Subscribe(TabButton button)
    {
        if (_tabButtons == null)
        {
            _tabButtons = new List<TabButton>();
        }

        _tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {

    }
    public void OnTabExit(TabButton button)
    {

    }

    public void OnTabSelected(TabButton button)
    {

    }
}
