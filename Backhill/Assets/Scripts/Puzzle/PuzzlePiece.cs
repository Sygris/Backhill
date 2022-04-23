using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public void Check(InventoryItemData reference)
    {
        foreach (var item in InventorySystem.Instance.Inventory[ItemType.Item])
        {
            if (item.Data == reference)
            {
                Place();
                return;
            }
        }

        Wrong();
    }

    private void Place()
    {
        Debug.Log("Placing the object");
    }

    private void Wrong()
    {
        Debug.Log("Object not found");
    }
}
