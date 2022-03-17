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
        SFX
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
                if (item.activeInHierarchy)
                    item.SetActive(false);
                else
                    item.SetActive(true);
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
                item.GetComponent<Animator>().SetTrigger(_animationParameter);
        }
    }


    public NewSceneParameters TriggerNewScene;
    [System.Serializable]
    public class NewSceneParameters
    {
        [SerializeField] private int _targetBuildIndex;

        public void ExecuteAction()
        {
            SceneManager.LoadScene(_targetBuildIndex);
        }
    }


    public PlaySFXParameters TriggerPlaySFX;
    [System.Serializable]
    public class PlaySFXParameters
    {
        [SerializeField] private AudioClip _targetSFX;
        [SerializeField] private List<Transform> _sfxLocation = new List<Transform>();
        [Range(0.0f, 1.0f)]
        [SerializeField] private float _sfxVolume;

        public void ExecuteAction()
        {
            foreach (Transform item in _sfxLocation)
            {
                AudioManager.instance.PlaySound(_targetSFX, item.position, _sfxVolume);
            }
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
            case TriggerEventType.SFX:
                TriggerPlaySFX.ExecuteAction();
                break;
            default:
                break;
        }
    }
}
