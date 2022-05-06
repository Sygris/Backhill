using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private PuzzleManager _puzzleManager;
    private InventoryItemData _reference;

    private void Awake()
    {
        _puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    public void Check(InventoryItemData reference)
    {
        foreach (var item in InventorySystem.Instance.Inventory[ItemType.Item])
        {
            if (item.Data == reference)
            {
                Place(item.Data.Prefab);
                return;
            }
        }

        Wrong();
    }

    private void Place(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);

        _puzzleManager.RemoveItem(gameObject);
        InventorySystem.Instance.Remove(_reference);

        Destroy(gameObject);
    }

    private void Wrong()
    {
        Debug.Log("Object not found");
    }
}
