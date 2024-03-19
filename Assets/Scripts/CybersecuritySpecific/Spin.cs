using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float SpinSpeed = 50f;
    private void Update()
    {
        transform.Rotate(0f, 0f, -SpinSpeed * Time.deltaTime, Space.Self);
    }
}
