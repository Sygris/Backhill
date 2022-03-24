using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    private bool _isGamePaused = false;

    public bool IsGamePaused
    {
        get { return _isGamePaused; }
    }

    public void Toggle()
    {
        _isGamePaused = !_isGamePaused;

        if (_isGamePaused)
            Pause();
        else
            Resume();
    }

    private void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GoToMainMenu(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
