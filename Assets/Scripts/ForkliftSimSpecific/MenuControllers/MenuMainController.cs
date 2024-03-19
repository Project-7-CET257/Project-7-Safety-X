using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuMainController : MonoBehaviour
{
    [SerializeField] string forkliftScene;
    [SerializeField] string cybersecurityScene;

    [SerializeField] GameObject optionsMenuPanel_1;
    [SerializeField] GameObject optionsMenuPanel_2;
    [SerializeField] GameObject optionsCloseButton_1;
    [SerializeField] GameObject optionsCloseButton_2;
    [SerializeField] GameObject optionsOpenButton;

    [SerializeField] GameObject gameSelectPanel;
    [SerializeField] GameObject forkliftSelectButton;
    [SerializeField] GameObject cybersecuritySelectButton;
    [SerializeField] GameObject gameSelectOpenButton;
    [SerializeField] GameObject gameSelectCloseButton;

    public void OptionsMenuClose()
    {
        EventSystem.current.SetSelectedGameObject(optionsOpenButton);
        optionsMenuPanel_1.SetActive(false);
        optionsMenuPanel_2.SetActive(false);
    }

    public void OptionsMenuOpen_1()
    {
        optionsMenuPanel_1.SetActive(true);
        optionsMenuPanel_2.SetActive(false);
        EventSystem.current.SetSelectedGameObject(optionsCloseButton_1);
    }
    public void OptionsMenuOpen_2()
    {
        optionsMenuPanel_1.SetActive(false);
        optionsMenuPanel_2.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionsCloseButton_2);
    }

    public void GameSelectOpen()
    {
        gameSelectPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(gameSelectCloseButton);
    }
    public void GameSelectClose()
    {
        gameSelectPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(gameSelectOpenButton);
    }

    public void StartForkliftGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(forkliftScene);
    }

    public void StartCybersecurityGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(cybersecurityScene);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}