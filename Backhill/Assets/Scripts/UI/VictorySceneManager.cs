using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySceneManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
