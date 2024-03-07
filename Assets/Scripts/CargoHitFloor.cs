using UnityEngine;

public class CargoHitFloor : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            new WaitForSeconds(1);
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}