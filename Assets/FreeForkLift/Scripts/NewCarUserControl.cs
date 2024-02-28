using System;
using UnityEngine;

[RequireComponent(typeof(NewCarController))]
[RequireComponent(typeof(InputManager))]

public class NewCarUserControl : MonoBehaviour
{
    private NewCarController m_Car; // the car controller we want to use
    private InputManager IM;

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<NewCarController>();
        IM = GetComponent<InputManager>();
    }


    private void FixedUpdate()
    {
        // pass the input to the car!
        float h = IM.horizontal;
        float v = IM.vertical;

        float handbrake = IM.handbrake;
        m_Car.Move(h, v, v, handbrake);
    }
}