using UnityEngine;

public class PalletInGoal : MonoBehaviour
{
    [SerializeField] private GameObject gameWinScreen;

     public int totalPallets, palletCheck = 0;

    private void Start()
    {
        totalPallets = GameObject.FindGameObjectsWithTag("Pallet").Length;
    }

    private void Update()
    {
        if (palletCheck == totalPallets)
        {
            gameWinScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Pallet")
        {
            palletCheck++;
        }
    }
}