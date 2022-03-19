using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventoryManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemdescription;

    public void Start()
    {
        InventorySystem.Instance.onInventoryChangedEvent += OnUpdateInventory;
    }

    private void OnUpdateInventory()
    {
        DrawInventory();
    }

    public void DrawInventory()
    {
        // Loop through every item in the inventory
        for (int i = 0; i < InventorySystem.Instance.Inventory.Count; i++)
        {
            // Loop through every item slot
            for (int j = 0; j < transform.childCount; j++)
            {
                // Get the UIInventoryItemSlot component of the item slot and set it to the correspondent item in the inventory
                UIInventoryItemSlot slot = transform.GetChild(i).GetComponent<UIInventoryItemSlot>();
                slot.Set(InventorySystem.Instance.Inventory[i]);
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int index = eventData.pointerCurrentRaycast.gameObject.transform.GetSiblingIndex();

        if (InventorySystem.Instance.Inventory.Count <= 0 || index > (InventorySystem.Instance.Inventory.Count - 1)) return;

        _itemName.text = InventorySystem.Instance.Inventory[index].Data.DisplayName;
        _itemdescription.text = InventorySystem.Instance.Inventory[index].Data.Description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _itemName.text = "Item Name";
        _itemdescription.text = "Item Description";
    }
}
