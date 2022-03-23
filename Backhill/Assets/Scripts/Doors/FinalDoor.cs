using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : Door
{
    [SerializeField] int _nextSceneIndex;

    public override void Open()
    {
        base.Open();

        SceneManager.LoadScene(_nextSceneIndex);
    }
}
