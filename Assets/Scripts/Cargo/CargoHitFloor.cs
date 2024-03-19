using UnityEngine;
using UnityEngine.EventSystems;

public class CargoHitFloor : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private MenuLoseController loseController;
    [SerializeField] private AudioSource forkliftEngine;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            forkliftEngine.Stop();
            loseController.loseMenuPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(restartButton);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}