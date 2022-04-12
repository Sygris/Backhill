using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData ReferenceItem;

    public delegate void Notification(string itemName);
    public static event Notification OnPickedUp;

    public void OnHandlePickupItem()
    {
        InventorySystem.Instance.Add(ReferenceItem);
        OnPickedUp?.Invoke(ReferenceItem.DisplayName);

        Destroy(gameObject);
    }
}
