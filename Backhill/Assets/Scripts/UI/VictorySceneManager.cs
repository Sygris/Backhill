using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySceneManager : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
