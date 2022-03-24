using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    [SerializeField] private List<Objective> _listOfObjectives = new List<Objective>();
    private int _currentIndex;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _objectivesText;
    [SerializeField] private string _textPrefix;

    #region Singleton variable member and proprety
    private static ObjectivesManager _instance;
    public static ObjectivesManager Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        #region Singleton Creation
        if (_instance != null && _instance != this)
            Destroy(this);
        else
            _instance = this;
        #endregion

        _currentIndex = 0;
        _objectivesText.text = _textPrefix + _listOfObjectives[_currentIndex].Description;
    }

    public void CompleteObjective()
    {
        if (_currentIndex + 1 >= _listOfObjectives.Count) return;

        _currentIndex++;
        _objectivesText.text = _textPrefix + _listOfObjectives[_currentIndex].Description;
    }
}
