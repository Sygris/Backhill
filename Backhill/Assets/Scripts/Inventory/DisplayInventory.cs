using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] private InventoryObject _inventory;
    [SerializeField] private GameObject _defaultSlot;

    //private Dictionary<InventorySlot, GameObject> _itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    private Dictionary<GameObject, InventorySlot> _itemsDisplayed = new Dictionary<GameObject, InventorySlot>();

    private void Start()
    {
        CreateSlots();  
    }

    private void Update()
    {
    }

    void UpdateSlots()
    {
        //foreach (var slot in _itemsDisplayed)
        //{
        //    if (slot.Value.item != null)
        //    {
        //        slot.Value.item.prefab = _inventory.container
        //    }
        //    else
        //    {

        //    }
        //}

        //for (int i = 0; i < _itemsDisplayed.Count; i++)
        //{
        //    if (_itemsDisplayed.Values[i]. != null)
        //    {
        //        slot.Value.item.prefab = _inventory.container
        //    }
        //    else
        //    {

        //    }
        //}
    }

    private void CreateSlots()
    {
        for (int i = 0; i < _inventory.container.Count; i++)
        {
            var obj = Instantiate(_defaultSlot, Vector3.zero, Quaternion.identity, transform);

            _itemsDisplayed.Add(obj, _inventory.container[i]);
        }
    }

    //void CreateDisplay()
    //{
    //    for (int i = 0; i < _inventory.container.Count; i++)
    //    {
    //        GameObject obj = null;

    //        if (_inventory.container[i].item != null)
    //        {
    //            obj = Instantiate(_inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
    //            obj.GetComponentInChildren<TextMeshProUGUI>().text = _inventory.container[i].amount.ToString();
    //        }
    //        else
    //            obj = Instantiate(_defaultSlot, Vector3.zero, Quaternion.identity, transform);

    //        _itemsDisplayed.Add(_inventory.container[i], obj);
    //    }

    //    foreach (var entry in _itemsDisplayed)
    //    {
    //        Debug.Log("Key: " + entry.Key);
    //        Debug.Log("Value: " + entry.Value);
    //    }
    //}

    //void UpdateDisplay()
    //{
    //    for (int i = 0; i < _inventory.container.Count; i++)
    //    {
    //        if (_itemsDisplayed.ContainsKey(_inventory.container[i]) && _inventory.container[i].item != null)
    //        {
    //            _itemsDisplayed[_inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = _inventory.container[i].amount.ToString();
    //        }
    //        else
    //        {
    //            var s = _itemsDisplayed[_inventory.container[i]];

    //            GameObject obj = Instantiate(_inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
    //            obj.GetComponentInChildren<TextMeshProUGUI>().text = _inventory.container[i].amount.ToString();
    //            s.transform.position = obj.transform.position;
    //            s = obj;

    //            _itemsDisplayed[_inventory.container[i]] = s;
    //        }
    //    }
    //}
}
