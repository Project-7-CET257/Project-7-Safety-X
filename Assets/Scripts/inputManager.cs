using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class inputManager : MonoBehaviour
{
    [HideInInspector] public float vertical;
    [HideInInspector] public float horizontal;
    [HideInInspector] public bool handbrake;
    [HideInInspector] public bool boosting;
    [HideInInspector] public bool gearUp;
    [HideInInspector] public bool gearDown;
    [HideInInspector] public bool pausePress;

    public void OnMoveVertical(InputValue value) => vertical = value.Get<Vector2>().y;
    public void OnMoveHorizontal(InputValue value) => horizontal = value.Get<Vector2>().x;
    public void OnHandbrake(InputValue value) => handbrake = Convert.ToBoolean(value.Get<float>());
    public void OnBoosting(InputValue value) => boosting = Convert.ToBoolean(value.Get<float>());
    public void OnGearUp(InputValue value) => gearUp = Convert.ToBoolean(value.Get<float>());
    public void OnGearDown(InputValue value) => gearDown = Convert.ToBoolean(value.Get<float>());
    public void OnPausePress(InputValue value) => pausePress = Convert.ToBoolean(value.Get<float>());
}