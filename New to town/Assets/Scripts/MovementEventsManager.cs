using System;
using UnityEngine;

public class MovementEventsManager : MonoBehaviour
{
    public event EventHandler OnLeftMouseButtonPressed;
    public event EventHandler OnEKeyPressed;
    public event EventHandler OnEscPressed;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
