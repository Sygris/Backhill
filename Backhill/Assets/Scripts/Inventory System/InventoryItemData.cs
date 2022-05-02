using UnityEngine;

public enum ItemType { Item, Note }

[CreateAssetMenu(fileName = "New Inventory Item Data", menuName = "Inventory System/Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string Id;
    public string DisplayName;
    public string Description;
    public Sprite Icon;
    public GameObject Prefab;
    public GameObject PrefabUI;
    public ItemType Type;
}
