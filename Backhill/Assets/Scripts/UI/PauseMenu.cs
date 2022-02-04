using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    private bool _isGamePaused = true;

    public bool IsGamePaused
    {
        get { return _isGamePaused; }
    }

    public void Toggle()
    {
        _isGamePaused = !_isGamePaused;

        if (_isGamePaused)
            Resume();
        else
            Pause();
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
}
