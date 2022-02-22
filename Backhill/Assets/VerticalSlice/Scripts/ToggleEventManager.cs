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
    public ToggleStatusParameters ToggleStatus;
    [System.Serializable]
    public class ToggleStatusParameters
    {
        [SerializeField] private List<GameObject> _targetObjects = new List<GameObject>();

        public void ExecuteAction()
        {
            Debug.Log("ToggleStatus");
        }
    }


    public ToggleMessageParameters ToggleMessage;
    [System.Serializable]
    public class ToggleMessageParameters
    {
        [SerializeField] private string _text;

        public void ExecuteAction()
        {
            Debug.Log(_text);
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
