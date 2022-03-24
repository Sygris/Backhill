using System.Collections.Generic;
using TMPro;
using UnityEngine;

// It will need to be rework. It works but I do not like how it's coded
public class ObjectiveSystem : MonoBehaviour
{
    [Header("Objectives")]
    [SerializeField] private List<string> _listOfObjectives = new List<string>();
    private int _currentObjective;

    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI _text;

    private static ObjectiveSystem _instance;
    public static ObjectiveSystem Instance { get { return _instance; } }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (_instance != null && _instance != this)
            Destroy(this);
        else
            _instance = this;
    }

    private void Start()
    {
        _currentObjective = 0;
        _text.text = _listOfObjectives[_currentObjective];
    }

    public void Complete()
    {
        // When the last objective is completed (animation)
        if (_currentObjective + 1 >= _listOfObjectives.Count) return;

        _currentObjective++;
        _text.text = _listOfObjectives[_currentObjective];
    }
}
