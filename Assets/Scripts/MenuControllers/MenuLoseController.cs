using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoseController : MonoBehaviour
{
    public GameObject loseMenuPanel;

    [SerializeField] private string menuScene = "StartScene";
    [SerializeField] private string playScene = "Overworld";

    public void Restart()
    {
        loseMenuPanel.SetActive(false);
        SceneManager.LoadScene(playScene);
        Time.timeScale = 1;
    }

    public void QuitToMainMenu()
    {
        loseMenuPanel.SetActive(false);
        SceneManager.LoadScene(menuScene);
    }
}