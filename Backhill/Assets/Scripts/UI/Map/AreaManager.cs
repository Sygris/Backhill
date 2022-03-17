using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaManager : MonoBehaviour
{
    [Header("Items Required to Collect")]
    [SerializeField] private List<ItemObject> _items = new List<ItemObject>();

    [Header("UI Settings")]
    [SerializeField] private Image _area;
    [SerializeField] private Color _areaCompleted;
    [SerializeField] private Color _areaIncompleted;

    public void UpdateUI(ItemObject item)
    {
        UpdateList(item);

        if (_items.Count == 0)
        {
            _area.color = _areaCompleted;
            Destroy(gameObject);
        }
        else
        {
            _area.color = _areaIncompleted;
        }
    }

    private void UpdateList(ItemObject item)
    {
        _items.Remove(item);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UpdateUI(null);
        }
    }
}
