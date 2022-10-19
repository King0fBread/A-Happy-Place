using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnObject : MonoBehaviour
{
    [SerializeField] private GameObject _objectToActivate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateObjectOnContactWithPlayer(_objectToActivate);
        }
    }
    private void ActivateObjectOnContactWithPlayer(GameObject objectToEnable)
    {
        objectToEnable.SetActive(true);
    }
}
