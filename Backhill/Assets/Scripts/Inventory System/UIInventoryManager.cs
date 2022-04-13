using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventoryManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("TextMeshPro References")]
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemdescription;

    [Header("UI References")]
    [SerializeField] private GameObject _itemNameGameObject;
    [SerializeField] private GameObject _itemDescriptionGameObject;

    [Header("Inspect Settings")]
    [SerializeField] private GameObject _test;

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

        if (!_itemNameGameObject.activeInHierarchy && !_itemDescriptionGameObject.activeInHierarchy)
        {
            _itemNameGameObject.SetActive(true);
            _itemDescriptionGameObject.SetActive(true);
        }

        _itemName.text = InventorySystem.Instance.Inventory[ItemType.Item][index].Data.DisplayName;
        _itemdescription.text = InventorySystem.Instance.Inventory[ItemType.Item][index].Data.Description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_itemNameGameObject.activeInHierarchy && _itemDescriptionGameObject.activeInHierarchy)
        {
            _itemNameGameObject.SetActive(false);
            _itemDescriptionGameObject.SetActive(false);

            _itemName.text = string.Empty;
            _itemdescription.text = string.Empty;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        int index = eventData.pointerCurrentRaycast.gameObject.transform.GetSiblingIndex();

        if (InventorySystem.Instance.Inventory[ItemType.Item].Count <= 0 || index > (InventorySystem.Instance.Inventory[ItemType.Item].Count - 1)) return;

        Instantiate(InventorySystem.Instance.Inventory[ItemType.Item][index].Data.Prefab);
    }
}
