using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] InventoryItemData _item;
    [SerializeField] Animator _animator;
    [SerializeField] string _animationName;
    [SerializeField] AudioClip _doorLockedSFX;
    [SerializeField] AudioClip _doorUnlockedSFX;
    protected bool _isDoorOpen = false;

    private void Start()
    {
        TryGetComponent<Animator>(out _animator);
    }

    private bool CheckItem()
    {
        if (_item == null)
        {
            _isDoorOpen = true;
            return true;
        }

        for (int i = 0; i < InventorySystem.Instance.Inventory[ItemType.Item].Count; i++)
        {
            if (InventorySystem.Instance.Inventory[ItemType.Item][i].Data.Id == _item.Id)
            {
                _isDoorOpen = true;
                return true;
            }
        }

        AudioManager.instance.PlaySound(_doorLockedSFX, transform.position, 1.0f);
        return false;
    }

    // It would have been better to clean the code and use the same function just to open the door
    // Due to being delayed I had to do it like this
    public void OpenWithoutKey()
    {
        AudioManager.instance.PlaySound(_doorUnlockedSFX, transform.position, 1.0f);

        _animator.Play(_animationName);
        gameObject.layer = 0;
    }

    public virtual void Open()
    {
        if (!CheckItem()) return;

        for (int i = 0; i < InventorySystem.Instance.Inventory[ItemType.Item].Count; i++)
        {
            if (InventorySystem.Instance.Inventory[ItemType.Item][i].Data.Id == _item.Id)
            {
                AudioManager.instance.PlaySound(_doorUnlockedSFX, transform.position, 1.0f);

                _animator.Play(_animationName);

                InventorySystem.Instance.Remove(InventorySystem.Instance.Inventory[ItemType.Item][i].Data);

                gameObject.layer = 0;
            }
        }
    }
}
