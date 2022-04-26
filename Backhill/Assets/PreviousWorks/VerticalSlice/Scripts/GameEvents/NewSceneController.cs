using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneController : MonoBehaviour
{
    [SerializeField] private int _buildIndex = 1;

    void Start()
    {
        GameEvents.Instance.TriggerNewScene += ChangeScene;
    }
    
    public void ChangeScene()
    {
        SceneManager.LoadScene(_buildIndex);
    }
}
