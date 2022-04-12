using TMPro;
using UnityEngine;

public class UIItemSlot : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _notificationBar;

    [Header("Default text")]
    [SerializeField] private string _prefixString;
    [SerializeField] private string _sufixString;

    private void ShowNotification(string itemName)
    {
        // Animation Fade In / Fade Out
        _notificationBar.SetActive(true);
        _text.text = _prefixString + " " + itemName + " " + _sufixString;
    }
    private void OnEnable()
    {
        ItemObject.OnPickedUp += ShowNotification;
    }

    private void OnDisable()
    {
        ItemObject.OnPickedUp -= ShowNotification;
    }
}
