using UnityEngine;

public class CollectObjective : Objective
{
    [SerializeField] private InventoryItemData _itemToCollect;

    public void CollectItem()
    {
        for (int i = 0; i < InventorySystem.Instance.Inventory[ItemType.Item].Count; i++)
        {
            if (InventorySystem.Instance.Inventory[ItemType.Item][i].Data.Id == _itemToCollect.Id)
            {
                Complete();
            }
        }
    }
}
