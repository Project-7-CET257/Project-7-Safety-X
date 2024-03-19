using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InputManager))]

public class PlayerPause : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private MenuPauseController pauseController;
    [SerializeField] private AudioSource forkliftEngine;

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
            forkliftEngine.Stop();
            pauseController.pauseMenuPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(resumeButton);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}