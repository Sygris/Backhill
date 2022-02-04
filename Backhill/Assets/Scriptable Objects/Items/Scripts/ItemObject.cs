using UnityEngine;

public enum ItemType 
{
    KeyItem,
    RecoveryItem,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType itemType;
    public string name;
    
    [TextArea(15, 20)]
    public string description;
}
