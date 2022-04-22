using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
    }

    private void CheckItem(InventoryItem reference)
    {
        if (InventorySystem.Instance.Inventory[ItemType.Item].Contains(reference))
        {
            Debug.Log("Noice");
        }
    }
}
