using System;
using System.Collections.Generic;
using UnityEngine;

// Class is a Monobehaviour for Debug proposes
public class InventorySystem : MonoBehaviour
{
    #region Inventory List and Dictionary
    private Dictionary<InventoryItemData, InventoryItem> _itemDictionary;
    //public List<InventoryItem> Inventory { get; private set; } 
    public Dictionary<ItemType, List<InventoryItem>> Inventory { get; private set; }
    #endregion

    #region Singleton variable member and property
    private static InventorySystem _instance;
    public static InventorySystem Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        #region Singleton Creation
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
            Init();
        }
        #endregion

        DontDestroyOnLoad(this);
    }

    private void Init()
    {
        Inventory = new Dictionary<ItemType, List<InventoryItem>>();
        Inventory.Add(ItemType.Item, new List<InventoryItem>());
        Inventory.Add(ItemType.Note, new List<InventoryItem>());

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
        // If the item being added is a note add it to the correct key and return
        if (referenceData.Type == ItemType.Note)
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            Inventory[ItemType.Note].Add(newItem);

            return;
        }

        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            Inventory[ItemType.Item].Add(newItem);
            _itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.StackSize == 0)
            {
                Inventory[ItemType.Item].Remove(value);
                _itemDictionary.Remove(referenceData);
            }
        }
    }
}
