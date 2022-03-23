using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : Door
{
    [SerializeField] int _nextSceneIndex;

    public override bool Open()
    {
        if (!base.Open()) return false;

        SceneManager.LoadScene(_nextSceneIndex);
        return true;
    }
}
