using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public List<Tutorial> tutorials = new List<Tutorial>();
    public TextMeshProUGUI tutorialText;

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

    private Tutorial currentTutorial;

    private void Start()
    {
        SetNextTutorial(0);    
    }

    private void Update()
    {
        if (currentTutorial)
            currentTutorial.CheckStatus();
    }

    public void CompletedTutorial()
    {
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

        tutorialText.text = currentTutorial.explanation;
    }

    public void CompletedAllTutorials()
    {
        tutorialText.text = "You completed all the tutorials, uhay";
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
