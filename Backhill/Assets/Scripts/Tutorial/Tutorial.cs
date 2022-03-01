using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int order;

    [Tooltip(tooltip:"Text that will be displayed to the player to guide them.")]
    [TextArea(3,10)]
    public string explanation;

    private void Awake()
    {
        //TutorialManager.Instance.tutorials.Add(this);
    }

    public virtual void CheckStatus() { }
}
