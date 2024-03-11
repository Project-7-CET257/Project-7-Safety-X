using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWinController : MonoBehaviour
{
    [SerializeField] private string menuScene = "StartScene";
    [SerializeField] private string playScene = "Overworld";

    public GameObject winMenuPanel;

    public void Resume()
    {
        winMenuPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        winMenuPanel.SetActive(false);
        SceneManager.LoadScene(playScene);
        Time.timeScale = 1;
    }

    public void QuitToMainMenu()
    {
        winMenuPanel.SetActive(false);
        SceneManager.LoadScene(menuScene);
    }
}