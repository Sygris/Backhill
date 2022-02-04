using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryObject _inventory;

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();

        if (item)
        {
            _inventory.AddItem(item.item, 1);

            Destroy(other.gameObject);
        }
    }
}
