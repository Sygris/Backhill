using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItemSlot : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _stackObject;
    [SerializeField] private TextMeshProUGUI _stackLabel;

    public void Set(InventoryItem item)
    {
        _icon.gameObject.SetActive(true);
        _icon.sprite = item.Data.Icon;

        _stackLabel.text = item.StackSize.ToString();
        
        if (item.StackSize > 1)
        {
            _stackObject.SetActive(true);
            return;
        }
    }

    public void Clean()
    {
        _icon.gameObject.SetActive(false);
        _stackObject.SetActive(false);
        _stackLabel.text = string.Empty;
    }
}
