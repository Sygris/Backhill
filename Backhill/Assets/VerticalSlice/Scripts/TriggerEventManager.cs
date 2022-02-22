using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventManager : MonoBehaviour
{
    public enum TriggerEventType
    {
        Status,
        Message,
        Animation
    }; public TriggerEventType TriggerMenu;

    #region TriggerActions
    public StatusTriggerParameters TriggerStatus;
    [System.Serializable]
    public class StatusTriggerParameters
    {
        [SerializeField] private List<GameObject> _targetObjects = new List<GameObject>();

        public void ExecuteAction()
        {
            foreach (GameObject item in _targetObjects)
            {
                item.SetActive(false);
            }
        }
    }


    public TriggerMessageParameters TriggerMessage;
    [System.Serializable]
    public class TriggerMessageParameters
    {
        [SerializeField] private string _text;

        public void ExecuteAction()
        {
            Debug.Log(_text);
        }
    }


    public TriggerAnimationParameters TriggerAnimation;
    [System.Serializable]
    public class TriggerAnimationParameters
    {
        [SerializeField] private List<GameObject> _targetObjects = new List<GameObject>();
        [SerializeField] private string _animationParameter;

        public void ExecuteAction()
        {
            foreach (GameObject item in _targetObjects)
            {
                item.GetComponent<Animator>().SetTrigger(_animationParameter);
            }
        }
    }
    #endregion

    public void ExecuteTriggerEvent()
    {
        switch (TriggerMenu)
        {
            case TriggerEventType.Status:
                TriggerStatus.ExecuteAction();
                break;
            case TriggerEventType.Message:
                TriggerMessage.ExecuteAction();
                break;
            case TriggerEventType.Animation:
                TriggerAnimation.ExecuteAction();
                break;
            default:
                break;
        }
    }
}
