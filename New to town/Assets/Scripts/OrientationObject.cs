using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationObject : MonoBehaviour
{
    [SerializeField] private Transform _cameraObj;
    private void Update()
    {
        transform.position = _cameraObj.position;
    }
}
