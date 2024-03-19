using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InputManager))]

public class PlayerPauseCA : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private MenuPauseControllerCA pauseController;

    private InputManager IM;

    private void Start()
    {
        IM = GetComponent<InputManager>();
    }

    private void Update()
    {
        PauseActivate();
    }

    private void PauseActivate()
    {
        if (IM.cancel)
        {
            pauseController.pauseMenuPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(resumeButton);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}