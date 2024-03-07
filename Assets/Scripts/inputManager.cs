using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public float vertical;
    [HideInInspector] public float horizontal;
    [HideInInspector] public float handbrake;
    [HideInInspector] public bool forkliftUp;
    [HideInInspector] public bool forkliftDown;
    [HideInInspector] public bool pausePress;
    [HideInInspector] public bool cameraSwitchUp;
    [HideInInspector] public bool cameraSwitchDown;

    public void OnVertical(InputValue value) => vertical = value.Get<Vector2>().y;
    public void OnHorizontal(InputValue value) => horizontal = value.Get<Vector2>().x;
    public void OnHandbrake(InputValue value) => handbrake = value.Get<float>();
    public void OnForkliftUp(InputValue value) => forkliftUp = Convert.ToBoolean(value.Get<float>());
    public void OnForkliftDown(InputValue value) => forkliftDown = Convert.ToBoolean(value.Get<float>());
    public void OnPausePress(InputValue value) => pausePress = Convert.ToBoolean(value.Get<float>());
    public void OnCameraSwitchUp(InputValue value) => cameraSwitchUp = Convert.ToBoolean(value.Get<float>());
    public void OnCameraSwitchDown(InputValue value) => cameraSwitchDown = Convert.ToBoolean(value.Get<float>());
}