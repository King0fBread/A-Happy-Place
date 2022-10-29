using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayEvents : MonoBehaviour
{
    public static GameplayEvents current;
    private void Awake()
    {
        current = this;
    }
    public event Action onSleepAttempted;
    public void SleepTriggered()
    {
        if (onSleepAttempted != null)
        {
            onSleepAttempted();
        }
    }
}
