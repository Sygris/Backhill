using UnityEngine;

[CreateAssetMenu(fileName = "New Key Item Object", menuName = "Inventory System/Items/Key Item")]
public class KeyItemObject : ItemObject
{
    public void Awake()
    {
        itemType = ItemType.KeyItem;
    }
}
