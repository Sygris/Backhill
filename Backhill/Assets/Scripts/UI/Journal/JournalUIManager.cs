using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class JournalUIManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _description;

    [Header("Note Color Settings")]
    [SerializeField] private Color _tabIdle;
    [SerializeField] private Color _tabHover;
    [SerializeField] private Color _tabSelected;

    public void OnPointerClick(PointerEventData eventData)
    {
        int index = eventData.pointerCurrentRaycast.gameObject.transform.GetSiblingIndex();
        if (InventorySystem.Instance.Inventory[ItemType.Note].Count <= 0 || index > (InventorySystem.Instance.Inventory[ItemType.Note].Count - 1)) return;

        _description.text = InventorySystem.Instance.Inventory[ItemType.Note][index].Data.Description;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        return;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int index = eventData.pointerCurrentRaycast.gameObject.transform.GetSiblingIndex();

        if (InventorySystem.Instance.Inventory[ItemType.Note].Count <= 0 || index > (InventorySystem.Instance.Inventory[ItemType.Note].Count - 1)) return;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        return;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        return;
    }
}
