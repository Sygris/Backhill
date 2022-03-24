using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : Door
{
    [SerializeField] int _nextSceneIndex;

    public override void Open()
    {
        base.Open();
        
        if(_isDoorOpen)
            SceneManager.LoadScene(_nextSceneIndex);
    }
}
