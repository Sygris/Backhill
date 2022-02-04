using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] private InventoryObject _inventory;
    [SerializeField] private GameObject _defaultSlot;

    private Dictionary<InventorySlot, GameObject> _itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    void CreateDisplay()
    {
        for (int i = 0; i < _inventory.container.Count; i++)
        {
            GameObject obj = null;

            if (_inventory.container[i].item != null)
            {
                obj = Instantiate(_inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = _inventory.container[i].amount.ToString();
            }
            else
                obj = Instantiate(_defaultSlot, Vector3.zero, Quaternion.identity, transform);
            
            _itemsDisplayed.Add(_inventory.container[i], obj);
        }
    }

    void UpdateDisplay()
    {
        for (int i = 0; i < _inventory.container.Count; i++)
        {
            if (_itemsDisplayed.ContainsKey(_inventory.container[i]) && _inventory.container[i].item != null)
            {
                _itemsDisplayed[_inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = _inventory.container[i].amount.ToString();
            }
            else
            {
                GameObject obj = null;

                if (_inventory.container[i].item != null)
                {
                    obj = Instantiate(_inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = _inventory.container[i].amount.ToString();
                }

                _itemsDisplayed.Add(_inventory.container[i], obj);
            }
        }
    }
}
