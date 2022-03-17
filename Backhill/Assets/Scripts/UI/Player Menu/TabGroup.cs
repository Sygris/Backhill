using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    [Header("Tab Buttons")]
    [SerializeField] private List<TabButton> _tabButtons;
    private TabButton _selectedTabButton;

    [Header("Tab Buttons Settings")]
    [SerializeField] private Color _tabIdle;
    [SerializeField] private Color _tabHover;
    [SerializeField] private Color _tabSelected;

    [Header("Pages")]
    [SerializeField] private List<GameObject> _pages;

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
        ResetTabs();

        if (_selectedTabButton == null && button != _selectedTabButton)
        {
            button.Background.color = _tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        _selectedTabButton = button;

        ResetTabs();
        button.Background.color = _tabSelected;

        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < _pages.Count; i++)
        {
            if (i == index)
                _pages[i].SetActive(true);
            else
                _pages[i].SetActive(false);
        }
    }

    private void ResetTabs()
    {
        foreach (var button in _tabButtons)
        {
            if (_selectedTabButton != null && button == _selectedTabButton)
                continue;

            button.Background.color = _tabIdle;
        }
    }
}
