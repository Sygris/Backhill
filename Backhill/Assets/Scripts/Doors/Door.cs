using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] InventoryItemData _item;
    [SerializeField] Animator _animator;
    [SerializeField] string _animationName;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public virtual void Open()
    {
        for (int i = 0; i < InventorySystem.Instance.Inventory[ItemType.Item].Count; i++)
        {
            if (InventorySystem.Instance.Inventory[ItemType.Item][i].Data.Id == _item.Id)
            {
                _animator.Play(_animationName);
                InventorySystem.Instance.Inventory[ItemType.Item][i].RemoveFromStack();
            }
        }
    }
}
