using UnityEngine;

public class ForkBottomCollision : MonoBehaviour
{
    public bool bottomCollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        bottomCollision = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        bottomCollision = false;
    }
}