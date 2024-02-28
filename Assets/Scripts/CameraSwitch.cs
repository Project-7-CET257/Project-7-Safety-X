using UnityEngine;

public class CameraSwitch : MonoBehaviour
{   
    [SerializeField] private GameObject VCamFP;
    [SerializeField] private GameObject VCamTP;
    [SerializeField] private GameObject VCamBV;
    [SerializeField] private float changeRate;

    private InputManager IM;
    private float nextSwitch = 0f;

    void Start()
    {
        IM = GetComponent<InputManager>();
    }

    void Update()
    {
        if (IM.cameraSwitch && Time.time >= nextSwitch)
        {
            nextSwitch = Time.time + 1f / changeRate;
            ChangePerspective();
        }
    }

    private void ChangePerspective()
    {
        if (VCamFP.activeSelf)
        {
            VCamTP.SetActive(true);
            VCamBV.SetActive(false);
            VCamFP.SetActive(false);
        }
        else if (VCamTP.activeSelf)
        {
            VCamTP.SetActive(false);
            VCamBV.SetActive(true);
            VCamFP.SetActive(false);
        }
        else if (VCamBV.activeSelf)
        {
            VCamTP.SetActive(false);
            VCamBV.SetActive(false);
            VCamFP.SetActive(true);
        }
    }
}