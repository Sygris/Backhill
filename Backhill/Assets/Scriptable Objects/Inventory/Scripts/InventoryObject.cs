using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();

    public void AddItem(ItemObject item, int amount)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == item)
            {
                container[i].AddAmount(amount);
                break;
            }
        }

        SetEmptySlot(item, amount);
    }

    public InventorySlot SetEmptySlot(ItemObject item, int amount)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == null)
            {
                container[i].UpdateSlot(item, amount);
                return container[i];
            }
        }

        // FUTURE: Handle inventory full
        return null;
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void UpdateSlot(ItemObject newItem, int newAmount)
    {
        item = newItem;
        amount = newAmount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}