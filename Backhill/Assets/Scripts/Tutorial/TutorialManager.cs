using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    public List<Tutorial> tutorials = new List<Tutorial>();
    public TextMeshProUGUI tutorialText;
    private Tutorial currentTutorial;

    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<TutorialManager>();

            return instance;
        }
    }

    private void Start()
    {
        SetNextTutorial(0);
        tutorialText.text = currentTutorial.explanation;
    }

    private void Update()
    {
        if (currentTutorial)
            currentTutorial.CheckStatus();
    }

    public void CompletedTutorial()
    {
        StartCoroutine(CompleteTutorial());
        SetNextTutorial(currentTutorial.order + 1);
    }

    public void SetNextTutorial(int currentOrder)
    {
        currentTutorial = GetTutorialByOrder(currentOrder);

        if (!currentTutorial)
        {
            CompletedAllTutorials();
            return;
        }
    }

    public void CompletedAllTutorials()
    {
        StartCoroutine(CompleteTutorials());
    }

    private IEnumerator CompleteTutorials()
    {
        tutorialText.text = "Tutorial Completed";

        yield return new WaitForSeconds(2.5f);

        ObjectivesManager.Instance.CompleteObjective();

        // Destroys the UI elements and the Tutorial Manager itself
        Destroy(tutorialText.gameObject.transform.parent.gameObject);
        Destroy(gameObject);
    }

    private IEnumerator CompleteTutorial()
    {
        tutorialText.fontStyle = FontStyles.Strikethrough;

        yield return new WaitForSeconds(2.5f);

        tutorialText.fontStyle = FontStyles.Normal;

        if (currentTutorial != null)
        {
            tutorialText.text = currentTutorial.explanation;
        }
    }

    public Tutorial GetTutorialByOrder(int order)
    {
        if (order >= tutorials.Count)
            return null;

        if (tutorials.Contains(tutorials[order]))
            return tutorials[order];

        return null;
    }
}
