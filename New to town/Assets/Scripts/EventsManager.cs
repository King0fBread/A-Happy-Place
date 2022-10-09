using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public event EventHandler OnLeftMouseButtonPressed;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftMouseButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
