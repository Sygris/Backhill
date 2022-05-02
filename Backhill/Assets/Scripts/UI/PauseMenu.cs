using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private InspectUI _inspectUI;

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
        {
            Resume();

            if (_inspectUI != null && _inspectUI.isActiveAndEnabled)
                _inspectUI.Close();
        }
    }

    public void CloseInspect()
    {
        _isGamePaused = !_isGamePaused;

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
        Destroy(FindObjectOfType<InventorySystem>());

        SceneManager.LoadScene(buildIndex);
        Time.timeScale = 1f;
    }
}
