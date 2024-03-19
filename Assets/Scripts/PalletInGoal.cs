using UnityEngine;
using UnityEngine.EventSystems;

public class PalletInGoal : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private MenuWinController winController;
    [SerializeField] private AudioSource forkliftEngine;

    private bool isGameWon = false;
    private int totalPallets, palletCheck = 0;

    private void Start()
    {
        totalPallets = GameObject.FindGameObjectsWithTag("Pallet").Length;
    }

    private void Update()
    {
        GameWinCheck();
    }

    private void GameWinCheck()
    {
        if (palletCheck == totalPallets && !isGameWon)
        {
            forkliftEngine.Stop();
            winController.winMenuPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(restartButton);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isGameWon = true;
            Time.timeScale = 0;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Pallet"))
        {
            palletCheck++;
            collision.gameObject.tag = "Collected Pallet";
        }
    }
}