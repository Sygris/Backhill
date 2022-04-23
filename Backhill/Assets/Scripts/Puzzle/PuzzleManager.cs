using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listOfItems = new List<GameObject>();
    [SerializeField] private GameObject _endGameObject;


    public void RemoveItem(GameObject item)
    {
        if (_listOfItems.Contains(item))
            _listOfItems.Remove(item);

        CheckPuzzle();
    }

    private void CheckPuzzle()
    {
        if (_listOfItems.Count > 0)
            return;

        _endGameObject.SetActive(true);
    }
}
