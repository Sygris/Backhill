using UnityEngine.InputSystem;

public class MovementTutorial : Tutorial
{
    public override void CheckStatus()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }
}
