using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TriggerObjective : Objective
{
    [SerializeField] private string _playerTag = "Player";

    private void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_playerTag))
        {
            Complete();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
