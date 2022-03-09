using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItemSlot : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private GameObject _stackObject;
    [SerializeField] private TextMeshProUGUI _stackLabel;

    public void Set(InventoryItem item)
    {
        _icon.sprite = item.Data.Icon;
        _label.text = item.Data.DisplayName;

        _stackLabel.text = item.StackSize.ToString();
        
        if (item.StackSize > 1)
        {
            _stackObject.SetActive(true);
            return;
        }
    }
}
