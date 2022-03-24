using UnityEngine;

public class CollectObjective : Objective
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private InventoryItemData _itemToCollect;


    public void CollectItem()
    {
        for (int i = 0; i < InventorySystem.Instance.Inventory[_itemType].Count; i++)
        {
            if (InventorySystem.Instance.Inventory[_itemType][i].Data.Id == _itemToCollect.Id)
            {
                Complete();
            }
        }
    }
}
