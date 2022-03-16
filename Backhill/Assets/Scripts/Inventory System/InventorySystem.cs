using System;
using System.Collections.Generic;
using UnityEngine;

// Class is a Monobehaviour for Debug proposes
public class InventorySystem : MonoBehaviour
{
    #region Inventory List and Dictionary
    private Dictionary<InventoryItemData, InventoryItem> _itemDictionary;
    public List<InventoryItem> Inventory { get; /*private*/ set; } 
    #endregion

    #region Singleton variable member and proprety
    private static InventorySystem _instance;
    public static InventorySystem Instance { get { return _instance; } }
    #endregion

    public event Action onInventoryChangedEvent;
    public void InventoryChanged()
    {
        onInventoryChangedEvent?.Invoke();
    }

    private void Awake()
    {
        #region Singleton Creation
        if (_instance != null && _instance != this)
            Destroy(this);
        else
            _instance = this; 
        #endregion

        Inventory = new List<InventoryItem>();
        _itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
            return value;

        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            Inventory.Add(newItem);
            _itemDictionary.Add(referenceData, newItem);
        }

        InventoryChanged();
    }

    public void Remove(InventoryItemData referenceData)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.StackSize == 0)
            {
                Inventory.Remove(value);
                _itemDictionary.Remove(referenceData);
            }
        }

        InventoryChanged();
    }
}
