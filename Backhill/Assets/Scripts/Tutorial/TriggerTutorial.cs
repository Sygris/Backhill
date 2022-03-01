using UnityEngine;

public class TriggerTutorial : Tutorial
{
    private bool isCurrentTutorial = false;

    public Transform target;

    public override void CheckStatus()
    {
        isCurrentTutorial = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCurrentTutorial)
            return;

        if (other.transform == target)
        {
            Debug.Log("Hmmm");
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }
    }
}
