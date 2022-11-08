using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void DisableThisObject()
    {
        gameObject.SetActive(false);
    }
}
