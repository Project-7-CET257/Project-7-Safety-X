using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOn : MonoBehaviour
{
    public GameObject startupScreen;
    public GameObject loginScreen;

    public Material onMaterial;
    public Material offMaterial;

    private bool isOn = false;
    private void OnMouseDown()
    {
        if (!isOn)
        {
            startupScreen.SetActive(true);
            gameObject.GetComponent<Renderer>().material = onMaterial;
            isOn = true;
            StartCoroutine(StartUp());
        }

        IEnumerator StartUp()
        {
            yield return new WaitForSeconds(5);

            loginScreen.SetActive(true);
            startupScreen.SetActive(false);
        }
            
    }
}
