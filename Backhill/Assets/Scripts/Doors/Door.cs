using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] InventoryItemData _item;
    [SerializeField] Animator _animator;
    [SerializeField] string _animationName;
    protected bool _isDoorOpen = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private bool CheckItem()
    {
        for (int i = 0; i < InventorySystem.Instance.Inventory[ItemType.Item].Count; i++)
        {
            if (InventorySystem.Instance.Inventory[ItemType.Item][i].Data.Id == _item.Id)
            {
                _isDoorOpen = true;
                return true;
            }
        }

        return false;
    }

    public virtual void Open()
    {
        if (!CheckItem()) return;

        for (int i = 0; i < InventorySystem.Instance.Inventory[ItemType.Item].Count; i++)
        {
            if (InventorySystem.Instance.Inventory[ItemType.Item][i].Data.Id == _item.Id)
            {
                _animator.Play(_animationName);

                // If any problem with this part comment the line 38 and uncomment the line 39
                InventorySystem.Instance.Remove(InventorySystem.Instance.Inventory[ItemType.Item][i].Data);
                //InventorySystem.Instance.Inventory[ItemType.Item][i].RemoveFromStack();
            }
        }
    }
}
