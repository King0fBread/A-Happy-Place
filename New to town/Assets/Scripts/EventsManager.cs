using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public event EventHandler OnLeftMouseButtonPressed;
    public event EventHandler OnEKeyPressed;
    //public event EventHandler OnShiftPressed;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftMouseButtonPressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnEKeyPressed?.Invoke(this, EventArgs.Empty);
        }
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    OnShiftPressed?.Invoke(this, EventArgs.Empty);
        //}
    }
}
