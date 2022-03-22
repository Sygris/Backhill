public class InteractableTutorial : Tutorial
{
    private bool _hasInteract = false;

    public override void CheckStatus()
    {
        if(_hasInteract)
            TutorialManager.Instance.CompletedTutorial();
    }

    public void Interact()
    {
        _hasInteract = true;
    }
}
