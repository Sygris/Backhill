using UnityEngine;

[CreateAssetMenu(fileName = "New Recovery Item Object", menuName = "Inventory System/Items/Recovery Item")]
public class RecoveryItemObject : ItemObject
{
    public int recoverHealthValue;

    public void Awake()
    {
        itemType = ItemType.RecoveryItem;
    }
}
