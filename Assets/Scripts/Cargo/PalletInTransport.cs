using UnityEngine;

public class PalletInTransport : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            this.gameObject.tag = "Pallet In Transport";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            this.gameObject.tag = "Pallet";
        }
    }
}