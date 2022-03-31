using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventoryManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemdescription;

    private void OnEnable()
    {
        CleanInventory();
        DrawInventory();
    }

    private void CleanInventory()
    {
        // Loop through every item slot
        for (int j = 0; j < transform.childCount; j++)
        {
            // Get the UIInventoryItemSlot component of the item slot and set it to the correspondent item in the inventory
            UIInventoryItemSlot slot = transform.GetChild(j).GetComponent<UIInventoryItemSlot>();
            slot.Clean();
        }
    }

    public void DrawInventory()
    {
        // Loop through every item in the inventory
        for (int i = 0; i < InventorySystem.Instance.Inventory[ItemType.Item].Count; i++)
        {
            // Loop through every item slot
            for (int j = 0; j < transform.childCount; j++)
            {
                // Get the UIInventoryItemSlot component of the item slot and set it to the correspondent item in the inventory
                UIInventoryItemSlot slot = transform.GetChild(i).GetComponent<UIInventoryItemSlot>();
                slot.Set(InventorySystem.Instance.Inventory[ItemType.Item][i]);
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int index = eventData.pointerCurrentRaycast.gameObject.transform.GetSiblingIndex();

        if (InventorySystem.Instance.Inventory[ItemType.Item].Count <= 0 || index > (InventorySystem.Instance.Inventory[ItemType.Item].Count - 1)) return;

        _itemName.text = InventorySystem.Instance.Inventory[ItemType.Item][index].Data.DisplayName;
        _itemdescription.text = InventorySystem.Instance.Inventory[ItemType.Item][index].Data.Description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _itemName.text = string.Empty;
        _itemdescription.text = string.Empty;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        int index = eventData.pointerCurrentRaycast.gameObject.transform.GetSiblingIndex();

        if (InventorySystem.Instance.Inventory[ItemType.Item].Count <= 0 || index > (InventorySystem.Instance.Inventory[ItemType.Item].Count - 1)) return;


    }
}
