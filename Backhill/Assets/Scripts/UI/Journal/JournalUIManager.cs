using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JournalUIManager : MonoBehaviour, /*IPointerEnterHandler,*/ /*IPointerExitHandler,*/ IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private GameObject _notesTitlesGrid;
    private List<TextMeshProUGUI> _titles = new List<TextMeshProUGUI>();

    [Header("Note Color Settings")]
    [SerializeField] private Color _tabIdle;
    [SerializeField] private Color _tabHover;
    [SerializeField] private Color _tabSelected;
    private int _noteSelected;

    private void Start()
    {
        foreach (Transform title in _notesTitlesGrid.transform)
        {
            _titles.Add(title.GetComponent<TextMeshProUGUI>());
        }

        UpdateJournal();
    }

    private void OnEnable()
    {
        UpdateJournal();
    }

    private void UpdateJournal()
    {
        for (int i = 0; i < _titles.Count; i++)
        {
            if (InventorySystem.Instance.Inventory[ItemType.Note].Count <= 0 || i > (InventorySystem.Instance.Inventory[ItemType.Note].Count - 1)) return;

            _titles[i].text = InventorySystem.Instance.Inventory[ItemType.Note][i].Data.DisplayName;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int index = eventData.pointerCurrentRaycast.gameObject.transform.GetSiblingIndex();
        if (InventorySystem.Instance.Inventory[ItemType.Note].Count <= 0 || index > (InventorySystem.Instance.Inventory[ItemType.Note].Count - 1)) return;

        _description.text = InventorySystem.Instance.Inventory[ItemType.Note][index].Data.Description;
        _backgroundImage.sprite = InventorySystem.Instance.Inventory[ItemType.Note][index].Data.Icon;

        _titles[_noteSelected].color = Color.white;

        _titles[index].color = _tabSelected;
        _noteSelected = index;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        return;
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    int index = eventData.pointerCurrentRaycast.gameObject.transform.GetSiblingIndex();

    //    if (InventorySystem.Instance.Inventory[ItemType.Note].Count <= 0 || index > (InventorySystem.Instance.Inventory[ItemType.Note].Count - 1)) return;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    _description.text = string.Empty;
    //    _backgroundImage.sprite = null;
    //}

    public void OnPointerUp(PointerEventData eventData)
    {
        return;
    }
}
