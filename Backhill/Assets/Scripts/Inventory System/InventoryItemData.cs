using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item Data", menuName = "Inventory System/Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string Id;
    public string DisplayName;
    public Sprite Icon;
    public GameObject Prefab;
}
