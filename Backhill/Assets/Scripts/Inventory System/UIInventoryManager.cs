using UnityEngine;

public class UIInventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;

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

    //public void AddInventorySlot(InventoryItem item)
    //{
    //    GameObject obj = Instantiate(_slotPrefab);
    //    obj.transform.SetParent(transform, false);

    //    UIInventoryItemSlot slot = obj.GetComponent<UIInventoryItemSlot>();
    //    slot.Set(item);
    //}
}
