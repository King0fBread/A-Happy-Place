using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightObject : MonoBehaviour
{
    [SerializeField] private FlashlightLogic _flashlightLogic;
    private void OnMouseDown()
    {
        _flashlightLogic.AllowFlashlightUse();
        gameObject.SetActive(false);
    }
}
