using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEventManager : MonoBehaviour
{
    public enum ToggleEventType
    {
        Status,
        Message
    }; public ToggleEventType ToggleMenu;

    #region ToggleActions
    public StatusParameters ToggleStatus;
    [System.Serializable]
    public class StatusParameters
    {
        [SerializeField] private List<GameObject> _targetObjects = new List<GameObject>();

        public void ExecuteAction()
        {
            Debug.Log("ToggleStatus");
        }
    }


    public MessageParameters ToggleMessage;
    [System.Serializable]
    public class MessageParameters
    {
        [SerializeField] private string _text;

        public void ExecuteAction()
        {
            Debug.Log(_text);
        }
    }


    public ToggleAnimationOnStatusParameters ToggleAnimationOnStatus;
    [System.Serializable]
    public class ToggleAnimationOnStatusParameters
    {
        [SerializeField] private List<GameObject> _targetObjects = new List<GameObject>();
        [SerializeField] private string _animationParameter;
        [SerializeField] private GameObject _targetStatusObject;

        public void ExecuteAction()
        {

        }
    }
    #endregion

    public void ExecuteToggleEvent()
    {
        switch (ToggleMenu)
        {
            case ToggleEventType.Status:
                ToggleStatus.ExecuteAction();
                break;
            case ToggleEventType.Message:
                ToggleMessage.ExecuteAction();
                break;
            default:
                break;
        }
    }
}
