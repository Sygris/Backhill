using System.Collections.Generic;
using UnityEngine;

public class CollectObjective : Objective
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private List<InventoryItemData> _itemsToCollect = new List<InventoryItemData>();

    public void CollectItem()
    {
        for (int i = 0; i < InventorySystem.Instance.Inventory[_itemType].Count; i++)
        {
            foreach (var item in _itemsToCollect)
            {
                if (InventorySystem.Instance.Inventory[_itemType][i] == null) break;

                if (InventorySystem.Instance.Inventory[_itemType][i].Data.Id == item.Id)
                {
                    _itemsToCollect.Remove(item);
                    if (_itemsToCollect.Count <= 0) Complete();
                    break;
                }
            }
        }
    }
}
