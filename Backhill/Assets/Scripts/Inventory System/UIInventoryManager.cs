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
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        DrawInventory();
    }

    public void DrawInventory()
    {
        foreach (InventoryItem item in InventorySystem.Instance.Inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(_slotPrefab);
        obj.transform.SetParent(transform, false);

        UIInventoryItemSlot slot = obj.GetComponent<UIInventoryItemSlot>();
        slot.Set(item);
    }
}
