using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEventManager : MonoBehaviour
{
    public enum TriggerEventType
    {
        Status,
        Message,
        Animation,
        Scene,
        PlaySFX,
        StopSFX
    };
    [Tooltip("Trigger Event Type")]
    public TriggerEventType TriggerMenu;

    #region TriggerActions
    [Tooltip("Reversing current active state of target object(s)")]
    public StatusParameters TriggerStatus;
    [System.Serializable]
    public class StatusParameters
    {
        [SerializeField] private List<GameObject> _targetObjects = new List<GameObject>();

        public void ExecuteAction()
        {
            foreach (GameObject item in _targetObjects)
            {
                if (item.activeInHierarchy)
                    item.SetActive(false);
                else
                    item.SetActive(true);
            }
        }
    }


    [Tooltip("Message to print to console window")]
    public MessageParameters TriggerMessage;
    [System.Serializable]
    public class MessageParameters
    {
        [Tooltip("Target text to print")]
        [SerializeField] private string _text;

        public void ExecuteAction()
        {
            Debug.Log(_text);
        }
    }


    [Tooltip("Play animations on target object(s)")]
    public AnimationParameters TriggerAnimation;
    [System.Serializable]
    public class AnimationParameters
    {
        [SerializeField] private List<GameObject> _targetObjects = new List<GameObject>();
        [Tooltip("Animation trigger parameter name")]
        [SerializeField] private string _animationParameter;

        public void ExecuteAction()
        {
            foreach (GameObject item in _targetObjects)
                item.GetComponent<Animator>().SetTrigger(_animationParameter);
        }
    }


    [Tooltip("Change current scene")]
    public NewSceneParameters TriggerNewScene;
    [System.Serializable]
    public class NewSceneParameters
    {
        [Tooltip("Build Index of target scene")]
        [SerializeField] private int _targetBuildIndex;

        public void ExecuteAction()
        {
            SceneManager.LoadScene(_targetBuildIndex);
        }
    }


    [Tooltip("Play SFX from target location")]
    public PlaySFXParameters TriggerPlaySFX;
    [System.Serializable]
    public class PlaySFXParameters
    {
        [Tooltip("Target audio clip to play")]
        [SerializeField] private AudioClip _targetSFX;
        [SerializeField] private List<Transform> _sfxLocation = new List<Transform>();
        [Tooltip("SFX Volume")]
        [Range(0.0f, 1.0f)]
        [SerializeField] private float _sfxVolume = 1.0f;

        public void ExecuteAction()
        {
            foreach (Transform item in _sfxLocation)
                AudioManager.instance.PlaySound(_targetSFX, item.position, _sfxVolume);
        }
    }


    [Tooltip("Stop all current SFX")]
    public StopSFXParameters TriggerStopSFX;
    [System.Serializable]
    public class StopSFXParameters
    {
        public void ExecuteAction()
        {
            AudioManager.instance.DisablePool();
        }
    }
    #endregion

    public void AddAnotherTriggerEvent()
    {
        gameObject.AddComponent<TriggerEventManager>();
    }

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
            case TriggerEventType.Scene:
                TriggerNewScene.ExecuteAction();
                break;
            case TriggerEventType.PlaySFX:
                TriggerPlaySFX.ExecuteAction();
                break;
            case TriggerEventType.StopSFX:
                TriggerStopSFX.ExecuteAction();
                break;
            default:
                break;
        }
    }
}
