using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuMainController : MonoBehaviour
{
    [SerializeField] string playScene;

    [SerializeField] GameObject optionsMenuPanel;
    [SerializeField] GameObject optionsCloseButton;
    [SerializeField] GameObject optionsOpenButton;

    public void OptionsMenuClose()
    {
        EventSystem.current.SetSelectedGameObject(optionsOpenButton);
        optionsMenuPanel.SetActive(false);
    }

    public void OptionsMenuOpen()
    {
        optionsMenuPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionsCloseButton);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(playScene);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}