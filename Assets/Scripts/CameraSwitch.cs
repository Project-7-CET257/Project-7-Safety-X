using UnityEngine;

public class CameraSwitch : MonoBehaviour
{   
    [SerializeField] private GameObject VCamFrontView;
    [SerializeField] private GameObject VCamLeftView;
    [SerializeField] private GameObject VCamRightView;
    [SerializeField] private GameObject VCamReverseView;
    [SerializeField] private float changeRate;

    private InputManager IM;
    private float nextSwitch = 0f;

    void Start()
    {
        IM = GetComponent<InputManager>();
    }

    void Update()
    {
        if (IM.cameraSwitchUp && Time.time >= nextSwitch)
        {
            nextSwitch = Time.time + 1f / changeRate;
            ChangePerspectiveUp();
        }
        if (IM.cameraSwitchDown && Time.time >= nextSwitch)
        {
            nextSwitch = Time.time + 1f / changeRate;
            ChangePerspectiveDown();
        }
        if (IM.cameraSwitchLeft && Time.time >= nextSwitch)
        {
            nextSwitch = Time.time + 1f / changeRate;
            ChangePerspectiveLeft();
        }
        if (IM.cameraSwitchRight && Time.time >= nextSwitch)
        {
            nextSwitch = Time.time + 1f / changeRate;
            ChangePerspectiveRight();
        }
    }

    private void ChangePerspectiveUp()
    {
        if (VCamReverseView.activeSelf)
        {
            VCamLeftView.SetActive(false);
            VCamRightView.SetActive(false);
            VCamReverseView.SetActive(false);
            VCamFrontView.SetActive(true);
        }
    }

    private void ChangePerspectiveDown()
    {
        if (VCamFrontView.activeSelf)
        {
            VCamLeftView.SetActive(false);
            VCamRightView.SetActive(false);
            VCamFrontView.SetActive(false);
            VCamReverseView.SetActive(true);
        }
    }

    private void ChangePerspectiveLeft()
    {
        if (VCamRightView.activeSelf)
        {
            VCamLeftView.SetActive(false);
            VCamRightView.SetActive(false);
            VCamFrontView.SetActive(true);
            VCamReverseView.SetActive(false);
        }
        else if (VCamFrontView.activeSelf)
        {
            VCamLeftView.SetActive(true);
            VCamRightView.SetActive(false);
            VCamFrontView.SetActive(false);
            VCamReverseView.SetActive(false);
        }
    }

    private void ChangePerspectiveRight()
    {
        if (VCamFrontView.activeSelf)
        {
            VCamLeftView.SetActive(false);
            VCamRightView.SetActive(true);
            VCamFrontView.SetActive(false);
            VCamReverseView.SetActive(false);
        }
        else if (VCamLeftView.activeSelf)
        {
            VCamLeftView.SetActive(false);
            VCamRightView.SetActive(false);
            VCamFrontView.SetActive(true);
            VCamReverseView.SetActive(false);
        }
    }
}