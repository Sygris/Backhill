using UnityEngine;

public abstract class Objective : MonoBehaviour
{
    [SerializeField] private string _description;
    public string Description { get { return _description; } }

    public void Complete()
    {
        ObjectivesManager.Instance.CompleteObjective();
    }
}
